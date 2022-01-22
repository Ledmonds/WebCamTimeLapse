using Emgu.CV;
using System.Drawing;

namespace WebCamTimeLapse.Services.WebCameraServices;

public class WebcamService : IWebcamService
{
    private readonly VideoCapture _camera = new VideoCapture();

    public Bitmap CaptureImage()
    {
        var frame = _camera.QueryFrame().ToBitmap();
        return frame;
    }
}
