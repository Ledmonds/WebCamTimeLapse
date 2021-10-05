using System;

namespace WebCamTimeLapse.Configurations
{
    class Configuration
    {
        public int IntervalTime { get; init; }
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Extension { get; set; }
        public (int,int) Resoloution { get; set; }

        public Configuration(int intervalTime, string outputPath, string fileName, string entension, (int, int) resoloution)
        {
            IntervalTime = intervalTime;
            Filepath = outputPath;
            Filename = fileName;
            Extension = entension;
            Resoloution = resoloution;
        }

        public Configuration(string[] args)
        {
            IntervalTime = (args.Length >= 1) ? int.Parse(args[0]) : 100;
            Filepath = (args.Length >= 2) ? args[1] : @"C:\";
            Filename = (args.Length >= 3) ? args[2] : "image_output";
            Extension = (args.Length >= 3) ? args[3] : "gif";
            Resoloution = (args.Length >= 5) ? (Convert.ToInt32(args[4]), Convert.ToInt32(args[5])) : (320, 480);
        }
    }
}
