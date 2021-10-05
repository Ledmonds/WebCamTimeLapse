using Emgu.CV;
using System;
using System.Drawing;

namespace WebCamTimeLapse.WebCameraService.WebCameraService
{
    public class EmuCVTakeImageService : IWebCameraService
    {
        public (int, int) Resoloution { get; set; }
        public EmuCVTakeImageService((int, int) resoloution)
        {
            Resoloution = resoloution;
        }

        public Bitmap TakeImage()
        {
           try
            {
                using (var capture = new VideoCapture())
                {
                    var image = capture.QueryFrame();
                    return (image != null) ? image.ToBitmap() : new Bitmap(Resoloution.Item1, Resoloution.Item2);
                }
            }
            catch (Exception e)
            {
                // Log and throw back a new blank image.
                Console.WriteLine($"Error: {DateTime.Now.ToString()}: {e.Message}");
                return new Bitmap(Resoloution.Item1, Resoloution.Item2);
            }
        }
    }
}
