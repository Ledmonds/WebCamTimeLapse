using AnimatedGif;
using System.Collections.Generic;
using System.Drawing;

namespace WebCamTimeLapse.ImageAnimatingService.ImageAnimatingService
{
    internal class AnimatedGifService : IImageAnimatingService
    {
        public int Interval { get; set; }
        public string Filepath { get; set; }
        public string Filename { get; init; }
        public string Extension { get; init; }

        public AnimatedGifService(int interval, string filepath, string filename, string extension)
        {
            Interval = interval;
            Filepath = filepath;
            Filename = filename;
            Extension = extension;            
        }

        public void AnimateGifToFile(IEnumerable<Image> images)
        {
            using var gif = AnimatedGif.AnimatedGif.Create($"{Filepath}\\{Filename}.{Extension}", Interval);
            foreach (var image in images)
            {
                gif.AddFrame(image, delay: -1, quality: GifQuality.Bit8);
            }
        }

        public void AnimateGifToStream(IEnumerable<Image> images)
        {
            throw new System.NotImplementedException();
        }
    }
}