using AnimatedGif;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace WebCamTimeLapse.Services.ImageAnimatingService
{
    class AnimatedGifService : IImageAnimatingService
    {
        public byte[] GenerateAnimatedGif(IEnumerable<Image> images)
        {
            using (var gif = AnimatedGif.AnimatedGif.Create("gif.gif", 33))
            {
                foreach(var image in images)
                {
                    gif.AddFrame(image, delay: -1, quality: GifQuality.Bit8);
                }

                return new byte[0];
            }
        }
    }
}
