using System.Collections.Generic;
using System.Drawing;
using WebCamTimeLapse.WebCameraService.WebCameraService;

namespace WebCamTimeLapse
{
    class Camera
    {
        public List<Image> ImageList { get; set; }
        private IWebCameraService imageCapture { get; set; }

        public Camera(IWebCameraService _diWebCameraService)
        {
            ImageList = new List<Image>();
            imageCapture = _diWebCameraService;
        }

        public void TakeImage()
        {
            var image = imageCapture.TakeImage();
            ImageList.Add(image);
        }
    }
}
