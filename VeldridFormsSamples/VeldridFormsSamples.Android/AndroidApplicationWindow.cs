﻿using System;
using System.Diagnostics;
using Veldrid;
using VeldridFormsSamples.SampleBase;

namespace VeldridFormsSamples.Droid
{
    public class AndroidApplicationWindow : IApplicationWindow
    {
        // This is supposed to be a DisposeCollectorResourceFactory but it crashes mono
        private ResourceFactory _disposeFactory;
        private readonly Stopwatch _sw;
        private double _previousSeconds;
        private VeldridSurfaceView _view;

        public event Action<GraphicsDevice, ResourceFactory, Swapchain> GraphicsDeviceCreated;
        public event Action GraphicsDeviceDestroyed;

        public uint Width => (uint)_view.Width;
        public uint Height => (uint)_view.Height;

        public SamplePlatformType PlatformType => SamplePlatformType.Mobile;

        public event Action<float> Rendering;
        public event Action Resized;
        public event Action<KeyEvent> KeyPressed;

        public AndroidApplicationWindow(VeldridSurfaceView view)
        {
            _view = view;
            _view.Rendering += OnViewRendering;
            _view.DeviceCreated += OnViewCreatedDevice;
            _view.Resized += OnViewResized;
            _view.DeviceDisposed += OnViewDeviceDisposed;
            _sw = Stopwatch.StartNew();
        }

        private void OnViewDeviceDisposed() => GraphicsDeviceDestroyed?.Invoke();

        private void OnViewResized() => Resized?.Invoke();

        private void OnViewCreatedDevice()
        {
            _disposeFactory = _view.GraphicsDevice.ResourceFactory;
            GraphicsDeviceCreated?.Invoke(_view.GraphicsDevice, _disposeFactory, _view.MainSwapchain);
            Resized?.Invoke();
        }

        private void OnViewRendering()
        {
            double newSeconds = _sw.Elapsed.TotalSeconds;
            double deltaSeconds = newSeconds - _previousSeconds;
            _previousSeconds = newSeconds;
            Rendering?.Invoke((float)deltaSeconds);
        }

        public void Run()
        {
            _view.RunContinuousRenderLoop();
        }
    }
}
