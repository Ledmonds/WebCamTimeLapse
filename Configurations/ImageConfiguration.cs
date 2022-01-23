namespace WebCamTimeLapse.Configurations;

public class ImageConfiguration
{
    public string Filename { get; init; } = "Animated_Image";
    public string Filepath { get; init; } = @"C:\\";
    public string Extension { get; init; } = "gif";
    public (int Width, int Height) Resoloution { get; init; } = (1680, 1280);
}