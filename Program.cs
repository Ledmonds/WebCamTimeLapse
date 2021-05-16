using AnimatedGif;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Timers;
using WebCamTimeLapse.DI;
using WebCamTimeLapse.Services.ImageAnimatingService;
using WebCamTimeLapse.Services.WebCameraService;

namespace WebCamTimeLapse
{
    class Program
    {
        private static Timer aTimer;
        private static IServiceScope scope;
        private static Camera camera;

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
            var cameraService = scope.ServiceProvider.GetRequiredService<IWebCameraService>();
            var imageAnimator = scope.ServiceProvider.GetRequiredService<IImageAnimatingService>(); // ToDo drop the T inversion here.
            camera = new Camera(cameraService, imageAnimator);


            // Create a timer and set a two second interval.
            // ToDo: Clean this code up into it's own nice little class or service. Timer Service maybe.
            // ToDo: Write Dispose Class.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = intervalTime;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;

            Console.WriteLine("Press a key to stop taking photos... ");
            Console.ReadLine();

            aTimer.Enabled = false;

            camera.SaveGifToDisk();

            return;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            camera.TakeImage();
        }
    }
}
