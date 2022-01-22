using System.Drawing;

namespace WebCamTimeLapse.Services.WebCameraServices;

public interface IWebcamService
{
    public Bitmap CaptureImage();
}
