using System.Collections.Generic;
using System.Drawing;

namespace WebCamTimeLapse.Services.CameraServices;

public interface ICameraService
{
    void TakeImage();
    IEnumerable<Bitmap> ReteriveCapturedImages();
}