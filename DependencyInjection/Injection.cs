using SimpleInjector;
using WebCamTimeLapse.Configurations;
using WebCamTimeLapse.Services.CameraServices;
using WebCamTimeLapse.Services.EventServices;
using WebCamTimeLapse.Services.GifServices;
using WebCamTimeLapse.Services.WebCameraServices;

namespace WebCamTimeLapse.DependencyInjection;

public static class Injection
{
    public static Container RegisterDependencyInjection()
    {
        var container = new Container();

        container.Register<IConfiguration, Configuration>(Lifestyle.Singleton);
        container.Register<IGifService, GifService>(Lifestyle.Singleton);
        container.Register<IWebcamService, WebcamService>(Lifestyle.Singleton);
        container.Register<ICameraService, CameraService>(Lifestyle.Singleton);
        container.Register<IEventHandler<TimerEvent>, EventHandler>(Lifestyle.Singleton);

        container.Verify();

        return container;
    }
}
