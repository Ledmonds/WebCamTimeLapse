using SimpleInjector;
using System.Timers;
using WebCamTimeLapse.Actions;
using WebCamTimeLapse.Configurations;
using WebCamTimeLapse.EventHandlers;
using WebCamTimeLapse.Events;
using WebCamTimeLapse.Repositories;
using WebCamTimeLapse.Services.CameraServices;
using WebCamTimeLapse.Services.GifServices;
using WebCamTimeLapse.Services.WebCameraServices;

namespace WebCamTimeLapse.DependencyInjection;

public static class Injection
{
    public static Container RegisterDependencyInjection()
    {
        var container = new Container();

        // Configurations
        container.Register<IConfiguration, Configuration>(Lifestyle.Singleton);

        // Repositories
        container.Register<IImageRepository, ImageRepository>(Lifestyle.Singleton);

        // Services
        container.Register<ICameraService, CameraService>();
        container.Register<IGifService, GifService>();
        container.Register<IWebcamService, WebcamService>();

        // Event Handlers
        container.Register<IEventHandler<TimerEvent>, EventHandler>();

        // Events
        container.Register<IEvent<Timer>, TimerEvent>();

        // Actions
        container.Register<IAction, TakeImageAction>();
        container.Register<IDisposableAction, CreateGifAction>();

        container.Verify();

        return container;
    }
}
