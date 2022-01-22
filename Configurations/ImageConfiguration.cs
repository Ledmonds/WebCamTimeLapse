namespace WebCamTimeLapse.Configurations;

public class ImageConfiguration
{
    public string Filename { get; init; }
    public string Filepath { get; init; }
    public string Extension { get; init; }
    public (int, int) Resoloution { get; init; }
}
