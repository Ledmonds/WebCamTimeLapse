using SimpleInjector;
using System;
using System.Timers;
using WebCamTimeLapse.DependencyInjection;
using WebCamTimeLapse.EventHandlers;
using WebCamTimeLapse.Events;

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
        var timerEvent = _container.GetInstance<IEvent<Timer>>();

        _eventHandler.StartEvent(timerEvent as TimerEvent);

        Console.WriteLine("Press a key to stop taking photos... ");
        Console.ReadLine();

        _eventHandler.StopAllEvents();

        return;
    }
}