﻿using System;
using VeldridFormsSamples.Instancing;
using VeldridFormsSamples.SampleBase;

namespace VeldridFormsSamples.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new VeldridStartupWindow("Instancing");
            var instancing = new InstancingApplication(window);
            window.Run();
        }
    }
}