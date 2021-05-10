using Microsoft.Extensions.DependencyInjection;
using System;
using System.Timers;
using WebCamTimeLapse.DI;
using WebCamTimeLapse.Services.WebCameraService;

namespace WebCamTimeLapse
{
    class Program
    {
        private static Timer aTimer;
        private static IServiceScope scope;
        private static IWebCameraService cameraService;

        // Properties    
        static void Main(string[] args)
        {
            // Setting up application command line variables.
            // ToDo: Pass these all off to the IWebCameraService Constructor.
            int intervalTime = (args.Length >= 1) ? int.Parse(args[0]) : 1000;
            string outputPath = (args.Length >= 2) ? args[1] : @"C:\";
            string namingPrefix = (args.Length >= 3) ? args[2] : "image_output";
            // ToDo: Add in some validation here on correct extension types.
            string imageExtension = (args.Length >= 3) ? args[3] : "png"; 

            // Setting up the Applications DI
            var serviceProvider = ServiceCollectionUtils.RegisterServices();
            scope = serviceProvider.CreateScope();
            cameraService = scope.ServiceProvider.GetRequiredService<IWebCameraService>();


            // Create a timer and set a two second interval.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = intervalTime;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();

            // ToDo: Write Dispose Class.
            return;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            var image = cameraService.TakeImage();
            image.Save(@$"C:\{DateTime.Now.Second.ToString()}.png");
        }
    }
}
