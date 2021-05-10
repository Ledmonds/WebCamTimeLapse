using Microsoft.Extensions.DependencyInjection;
using WebCamTimeLapse.DI;
using WebCamTimeLapse.Services.WebCameraService;

namespace WebCamTimeLapse
{
    class Program
    {
        // Properties    
        static void Main(string[] args)
        {
            // Setting up application command line variables.
            int intervalTime = (args.Length >= 1) ? int.Parse(args[0]) : 250;
            string outputPath = (args.Length >= 2) ? args[1] : @"C:\";
            string namingPrefix = (args.Length >= 3) ? args[2] : "image_output";
            string imageExtension = (args.Length >= 3) ? args[3] : "png"; // Add in some validation here on correct extension types.

            // Setting up the Applications DI
            var serviceProvider = ServiceCollectionUtils.RegisterServices();
            IServiceScope scope = serviceProvider.CreateScope();

            



            var cameraService = scope.ServiceProvider.GetRequiredService<IWebCameraService>();
            var image = cameraService.TakeImage();
            image.Save($"{outputPath}{namingPrefix}.{imageExtension}");





            //https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer.elapsed?view=net-5.0

            // Write Dispose Class.
            return;
        }
    }
}
