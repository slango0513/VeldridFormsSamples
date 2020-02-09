using VeldridFormsSamples.AnimatedMesh;
using VeldridFormsSamples.ComputeTexture;
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
            //var computeTexture = new ComputeTextureApplication(window);
            //var AnimatedMesh = new AnimatedMeshApplication(window);
            window.Run();
        }
    }
}
