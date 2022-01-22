namespace WebCamTimeLapse.Configurations;

public class Configuration : IConfiguration
{
    private ImageConfiguration _image;
    private AnimationConfiguration _animation;

    public Configuration()
    {
        _image = new ImageConfiguration()
        {
            Filename = "Animated_Image",
            Filepath = @"C:\\",
            Extension = "gif",
            Resoloution = (320, 468),
        };

        _animation = new AnimationConfiguration()
        {
            IntervalTime = 500,
        };
    }

    public ImageConfiguration Image => _image;
    public AnimationConfiguration Animation => _animation;
}

public interface IConfiguration
{
    ImageConfiguration Image { get; }
    AnimationConfiguration Animation { get; }
}