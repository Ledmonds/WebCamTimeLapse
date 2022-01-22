using SimpleInjector;
using System;
using System.Timers;
using WebCamTimeLapse.DependencyInjection;
using WebCamTimeLapse.Services.CameraServices;
using WebCamTimeLapse.Services.GifServices;

namespace WebCamTimeLapse;

class Program
{
    static readonly Container container;

    static Program()
    {
        container = Injection.RegisterDependencyInjection();
    }

    static void Main(string[] args)
    {
        var eventTimer = RegisterEventTimer();

        Console.WriteLine("Press a key to stop taking photos... ");
        Console.ReadLine();

        eventTimer.Enabled = false;

        AnimateGifToFile();

        return;
    }

    private static Timer RegisterEventTimer()
    {
        var imageCaptureTimer = new Timer();
        imageCaptureTimer.Interval = 30;
        imageCaptureTimer.Elapsed += OnTimedEvent;
        imageCaptureTimer.Enabled = true;

        return imageCaptureTimer;
    }

    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        var cameraService = container.GetInstance<ICameraService>();
        cameraService.TakeImage();
    }

    private static void AnimateGifToFile()
    {
        var cameraService = container.GetInstance<ICameraService>();
        var gifService = container.GetInstance<IGifService>();

        gifService.AnimateGifToFile(cameraService.ReteriveCapturedImages());
    }
}