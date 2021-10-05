using System.Drawing;

namespace WebCamTimeLapse.WebCameraService.WebCameraService
{
    public interface IWebCameraService
    {
        public Bitmap TakeImage();
    }
}
