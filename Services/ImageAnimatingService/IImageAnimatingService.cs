using System.Collections.Generic;
using System.Drawing;

namespace WebCamTimeLapse.ImageAnimatingService.ImageAnimatingService
{
    public interface IImageAnimatingService
    {
        void AnimateGifToFile(IEnumerable<Image> images);
        void AnimateGifToStream(IEnumerable<Image> images);
    }
}
