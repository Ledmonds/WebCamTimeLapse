namespace WebCamTimeLapse.Configurations;

public interface IConfiguration
{
    ImageConfiguration Image { get; }
    AnimationConfiguration Animation { get; }
    WebCamConfiguraiton WebCam { get; }
}
