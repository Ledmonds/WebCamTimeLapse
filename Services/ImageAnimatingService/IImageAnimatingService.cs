using System.Collections.Generic;
using System.Drawing;

namespace WebCamTimeLapse.Services.ImageAnimatingService
{
    public interface IImageAnimatingService
    {
        /// <summary>
        /// Generates an animated Gif image.
        /// </summary>
        /// <returns></returns>
        void GenerateAnimatedGif(IEnumerable<Image> images, string filepath);
    }
}
