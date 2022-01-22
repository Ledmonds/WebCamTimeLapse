using SimpleInjector;
using System;
using System.Timers;
using WebCamTimeLapse.DependencyInjection;
using WebCamTimeLapse.Services.CameraServices;
using WebCamTimeLapse.Services.EventServices;
using WebCamTimeLapse.Services.GifServices;

namespace WebCamTimeLapse;

class Program
{
    private static readonly Container _container;
    private static readonly IEventHandler<TimerEvent> _eventHandler;

    static Program()
    {
        _container = Injection.RegisterDependencyInjection();
        _eventHandler = _container.GetInstance<IEventHandler<TimerEvent>>();
    }

    static void Main()
    {
        _eventHandler.StartEvent();

        Console.WriteLine("Press a key to stop taking photos... ");
        Console.ReadLine();

        _eventHandler.DeregisterEvent();

        AnimateGifToFile();

        return;
    }

    private static void AnimateGifToFile()
    {
        var cameraService = _container.GetInstance<ICameraService>();
        var gifService = _container.GetInstance<IGifService>();

        gifService.AnimateGifToFile(cameraService.ReteriveCapturedImages());
    }
}