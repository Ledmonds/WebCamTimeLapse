using WebCamTimeLapse.Repositories;
using WebCamTimeLapse.Services.WebCameraServices;

namespace WebCamTimeLapse.Services.CameraServices;

class CameraService : ICameraService
{
    private IImageRepository _imageRepository;
    private IWebcamService _camera;

    public CameraService(IWebcamService camera, IImageRepository repository)
    {
        _camera = camera;
        _imageRepository = repository;
    }

    public void CaptureFrame()
    {
        var image = _camera.CaptureImage();
        _imageRepository.Add(image);
    }
}