using System.Collections.Generic;
using System.Drawing;

namespace WebCamTimeLapse.Services.WebCameraService
{
    public interface IWebCameraService
    {
        /// <summary>
        /// Resolves an image via the TakeImage Interface
        /// </summary>
        /// <returns></returns>
        public Bitmap TakeImage();
    }
}
