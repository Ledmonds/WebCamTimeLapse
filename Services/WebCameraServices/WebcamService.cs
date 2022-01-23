using Emgu.CV;
using System.Drawing;
using WebCamTimeLapse.Configurations;

namespace WebCamTimeLapse.Services.WebCameraServices;

public class WebcamService : IWebcamService
{
    private readonly IConfiguration _configuration;
    private readonly VideoCapture _camera = new VideoCapture();

    public WebcamService(IConfiguration configuration)
    {
        _configuration = configuration;
        var captureResoloution = _configuration.Image.Resoloution;

        _camera.Set(Emgu.CV.CvEnum.CapProp.FrameWidth, captureResoloution.Width);
        _camera.Set(Emgu.CV.CvEnum.CapProp.FrameHeight, captureResoloution.Height);
    }

    public Bitmap CaptureImage()
    {
        var frame = _camera.QueryFrame().ToBitmap();
        return frame;
    }
}
