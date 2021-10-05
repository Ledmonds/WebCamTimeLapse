using System;
using System.Timers;
using WebCamTimeLapse.Configurations;
using WebCamTimeLapse.ImageAnimatingService.ImageAnimatingService;
using WebCamTimeLapse.WebCameraService.WebCameraService;

namespace WebCamTimeLapse
{
    class Program
    {
        private static Timer aTimer;
        private static Camera camera;

        // Properties    

        static void Main(string[] args)
        {
            var configuration = new Configuration(args);
            var imageCapture = new EmuCVTakeImageService(configuration.Resoloution);
            var imageAnimator = new AnimatedGifService(configuration.IntervalTime, configuration.Filepath, configuration.Filename, configuration.Extension);

            camera = new Camera(imageCapture);


            // Create a timer and set a two second interval.s
            // ToDo: Clean this code up into it's own nice little class or service. Timer Service maybe.
            // ToDo: Write Dispose Class.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = configuration.IntervalTime;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;

            Console.WriteLine("Press a key to stop taking photos... ");
            Console.ReadLine();

            aTimer.Enabled = false;

            imageAnimator.AnimateGifToFile(camera.ImageList);

            return;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            camera.TakeImage();
        }
    }
}
