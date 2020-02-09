using Android.Content;
using Veldrid;
using VeldridFormsSamples.AnimatedMesh;
using VeldridFormsSamples.ComputeTexture;
using VeldridFormsSamples.Droid;
using VeldridFormsSamples.Instancing;
using VeldridFormsSamples.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(VeldridView), typeof(VeldridViewRenderer))]
namespace VeldridFormsSamples.Droid
{
    public class VeldridViewRenderer : ViewRenderer<VeldridView, VeldridSurfaceView>
    {
        public VeldridViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VeldridView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == default)
            {
                return;
            }

            var debug = false;
#if DEBUG
            debug = true;
#endif
            var options = new GraphicsDeviceOptions(debug, PixelFormat.R16_UNorm, false, ResourceBindingModel.Improved, true, true);
            var backend = GraphicsDevice.IsBackendSupported(GraphicsBackend.Vulkan) ? GraphicsBackend.Vulkan : GraphicsBackend.OpenGLES;
            var view = new VeldridSurfaceView(Context, backend, options);
            var window = new AndroidApplicationWindow(view);
            window.GraphicsDeviceCreated += (g, r, s) => window.Run();
            var app = new InstancingApplication(window);
            //var app = new ComputeTextureApplication(window);
            //var app = new AnimatedMeshApplication(window);

            SetNativeControl(view);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
