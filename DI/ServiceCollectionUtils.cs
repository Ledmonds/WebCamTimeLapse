using Microsoft.Extensions.DependencyInjection;
using WebCamTimeLapse.Services.WebCameraService;

namespace WebCamTimeLapse.DI
{
    public static class ServiceCollectionUtils
    {
        /// <summary>
        /// Handles registering the DI services. Add, remove and edit DI Injected services here.
        /// </summary>
        /// <returns></returns>
        public static ServiceProvider RegisterServices()
        {
            // Service Collection
            var services = new ServiceCollection();
            services.AddSingleton<IWebCameraService, EmuCVTakeImageService>();
            return services.BuildServiceProvider();
        }
    }
}
