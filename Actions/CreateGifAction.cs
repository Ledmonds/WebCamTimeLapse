using WebCamTimeLapse.Repositories;
using WebCamTimeLapse.Services.GifServices;

namespace WebCamTimeLapse.Actions;

public class CreateGifAction : IDisposableAction
{
    private readonly IImageRepository _imageRepository;
    private readonly IGifService _gifService;

    public CreateGifAction(IImageRepository imageRepository, IGifService gifService)
    {
        _imageRepository = imageRepository;
        _gifService = gifService;
    }

    public void Invoke()
    {
        var images = _imageRepository.GetAll();
        _gifService.AnimateGifToFile(images); 
    }
}
