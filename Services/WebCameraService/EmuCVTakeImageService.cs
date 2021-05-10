using Emgu.CV;
using System;
using System.Drawing;

namespace WebCamTimeLapse.Services.WebCameraService
{
    public class EmuCVTakeImageService : IWebCameraService
    {
        public Bitmap TakeImage()
        {
           try
            {
                using (VideoCapture capture = new VideoCapture())
                {
                    var image = capture.QueryFrame();
                    return image.ToBitmap();
                }
            }
            catch (Exception e)
            {
                // Action Log
                return null;
            }
        }

        public string Test()
        {
            return "Output";
        }
    }
}
