using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WebCamTimeLapse.Services.WebCameraServices;

namespace WebCamTimeLapse.Services.CameraServices;

class CameraService : ICameraService
{
    private IEnumerable<Bitmap> _imageList { get; set; } = new List<Bitmap>();
    private IWebcamService _camera { get; init; }

    public CameraService(IWebcamService camera)
    {
        _camera = camera;
    }

    public void TakeImage()
    {
        _imageList = _imageList.Append(_camera.CaptureImage());
    }

    public IEnumerable<Bitmap> ReteriveCapturedImages()
    {
        return _imageList;
    }
}
