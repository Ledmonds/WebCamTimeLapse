namespace WebCamTimeLapse.Configurations;

public class Configuration : IConfiguration
{
    private ImageConfiguration _image = new ImageConfiguration();
    private AnimationConfiguration _animation = new AnimationConfiguration();
    private WebCamConfiguraiton _webCam = new WebCamConfiguraiton();

    public ImageConfiguration Image => _image;
    public AnimationConfiguration Animation => _animation;
    public WebCamConfiguraiton WebCam => _webCam;
}