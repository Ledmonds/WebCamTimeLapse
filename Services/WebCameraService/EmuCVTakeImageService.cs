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
                using (var capture = new VideoCapture())
                {
                    var image = capture.QueryFrame();
                    return (image != null) ? image.ToBitmap() : new Bitmap(480, 320);
                }
            }
            catch (Exception e)
            {
                // Log and throw back a new blank image.
                Console.WriteLine($"Error: {DateTime.Now.ToString()}: {e.Message}");
                return new Bitmap(480, 320);
            }
        }
    }
}
