using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Veldrid;
using VeldridFormsSamples.Instancing;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace VeldridFormsSamples.Droid
{
    [Activity(Label = "VeldridFormsSamples", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    [Activity(Label = "VeldridFormsSamples", Theme = "@style/MainTheme", MainLauncher = false,
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity_ : AppCompatActivity
    {
        private VeldridSurfaceView view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            var debug = false;
#if DEBUG
            debug = true;
#endif
            var options = new GraphicsDeviceOptions(debug, PixelFormat.R16_UNorm, false, ResourceBindingModel.Improved, true, true);
            var backend = GraphicsDevice.IsBackendSupported(GraphicsBackend.Vulkan) ? GraphicsBackend.Vulkan : GraphicsBackend.OpenGLES;
            view = new VeldridSurfaceView(this, backend, options);
            var window = new AndroidApplicationWindow(view);
            window.GraphicsDeviceCreated += (g, r, s) => window.Run();
            var app = new InstancingApplication(window);

            SetContentView(view);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnPause()
        {
            base.OnPause();
            view.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            view.OnResume();
        }
    }
}
