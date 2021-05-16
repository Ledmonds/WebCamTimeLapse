using AnimatedGif;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace WebCamTimeLapse.Services.ImageAnimatingService
{
    class AnimatedGifService : IImageAnimatingService
    {
        public void GenerateAnimatedGif(IEnumerable<Image> images, string filePath)
        {
            using (var gif = AnimatedGif.AnimatedGif.Create($"{filePath}.gif", 500))
            {
                foreach(var image in images)
                {
                    gif.AddFrame(image, delay: -1, quality: GifQuality.Bit8);
                }
            }
        }
    }
}
