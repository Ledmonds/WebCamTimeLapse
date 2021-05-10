using Emgu.CV;
using System;
using System.Drawing;

namespace WebCamTimeLapse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            VideoCapture capture = new VideoCapture(); //create a camera capture
            var image = capture.QueryFrame(); //take a picture

            image.Save(@"C:\output.image.png");
        }
    }
}
