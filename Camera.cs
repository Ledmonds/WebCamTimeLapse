using AnimatedGif;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using WebCamTimeLapse.Services.ImageAnimatingService;

namespace WebCamTimeLapse.Services.WebCameraService
{
    class Camera
    {
        // Properties
        public List<Image> ImageList { get; set; }
        private IWebCameraService cameraService { get; set; }
        private IImageAnimatingService imageAnimatorService { get; set; }

        private string filepath;
        private string filename;
        private string singleImageExtension;


        // Constructor
        public Camera()
        {
            ImageList = new List<Image>();
            cameraService = null;
            imageAnimatorService = null;

            filepath = string.Empty;
            filename = string.Empty;
            singleImageExtension = string.Empty;
        }
        public Camera(IWebCameraService _diWebCameraService, IImageAnimatingService _imageAnimatorService, string _filepath = @"C:\", string _filename = "default_name", string _singleImageExtension = "png")
        {
            ImageList = new List<Image>();
            cameraService = _diWebCameraService;
            imageAnimatorService = _imageAnimatorService;

            filepath = _filepath;
            filename = _filename;
            singleImageExtension = _singleImageExtension;
        }


        // Methods
        /// <summary>
        /// Saves the image files to disk.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="filename"></param>
        /// <param name="extension"></param>
        public void SaveImagesToDisk()
        {
            if (ImageList != null && ImageList.Count() > 0)
            {
                for (int i = 0; i < ImageList.Count(); ++i)
                {
                    ImageList.ElementAt(i).Save($"{filepath}{filename}_{i}.{singleImageExtension}");
                }
            }
        }

        /// <summary>
        /// Saves the collected images out to an animated gif file.
        /// </summary>
        public void SaveGifToDisk(byte[] inputStream)
        {
            try
            {
                File.WriteAllBytes($"{filepath}{filename}.gif", inputStream);
            }
            catch (Exception e)
            {
                // ToDo: Log
            }
        }

        private byte[] generateGifFromImages()
        {
            return new byte[0];
        }
    }
}
