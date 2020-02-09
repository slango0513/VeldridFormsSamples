using VeldridFormsSamples.AnimatedMesh;
using VeldridFormsSamples.ComputeParticles;
using VeldridFormsSamples.ComputeTexture;
using VeldridFormsSamples.Instancing;
using VeldridFormsSamples.Offscreen;
using VeldridFormsSamples.SampleBase;

namespace VeldridFormsSamples.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            //new GettingStarted().Run();

            var window = new VeldridStartupWindow("Instancing");
            //var app = new AnimatedMeshApplication(window);
            //var app = new ComputeParticlesApplication(window);
            //var app = new ComputeTextureApplication(window);
            var app = new InstancingApplication(window);
            //var app = new OffscreenApplication(window);
            window.Run();
        }
    }
}
