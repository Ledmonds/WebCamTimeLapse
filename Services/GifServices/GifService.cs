using AnimatedGif;
using System.Collections.Generic;
using System.Drawing;
using WebCamTimeLapse.Configurations;

namespace WebCamTimeLapse.Services.GifServices;

internal class GifService : IGifService
{
    private IConfiguration _configuration;
    private GifQuality _quality = GifQuality.Bit8;
    private int delay = -1;

    public GifService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void AnimateGifToFile(IReadOnlyCollection<Image> images)
    {
        using var animator = AnimatedGif.AnimatedGif
            .Create(GenerateCompleteFilePath(), _configuration.Animation.IntervalTime);

        foreach (var image in images)
        {
            animator.AddFrame(image, delay: delay, quality: _quality);
        }
    }

    private string GenerateCompleteFilePath()
    {
        return $"{_configuration.Image.Filepath}\\{_configuration.Image.Filename}.{_configuration.Image.Extension}";
    }
}
