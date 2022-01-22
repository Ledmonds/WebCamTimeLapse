using WebCamTimeLapse.Services.CameraServices;

namespace WebCamTimeLapse.Actions;

public class TakeImageAction : IAction
{
    private readonly ICameraService _cameraService;

    public TakeImageAction(ICameraService cameraService)
    {
        _cameraService = cameraService;
    }

    public void Invoke()
    {
        _cameraService.CaptureFrame();
    }
}