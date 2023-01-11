using System.Drawing.Imaging;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.IO;

namespace Scorerecord.Helper
{
    public class MediaHelper
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public MediaHelper(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;

        }
        public static string UploadOriginalFile(IFormFile file, string urlPath)
        {
            var image = Image.FromStream(file.OpenReadStream());
            var resized = new Bitmap(image);
            using var imageStream = new MemoryStream();
            resized.Save(imageStream, ImageFormat.Jpeg);
            var imageBytes = imageStream.ToArray();
            return UploadFile(imageBytes, urlPath);
        }

        //public static string UploadLargeFile(IFormFile file, int width, int height, string urlPath)
        //{
        //    var image = Image.FromStream(file.OpenReadStream());
        //    var imageBytes = ResizeImageOriginalRatio(image, width, height);
        //    return UploadFile(imageBytes, urlPath);
        //}
        public static string UploadLargeFile(IFormFile sourceImage, string urlPath)
        {
            string filename = string.Empty;
            System.Drawing.Image souimage =
                System.Drawing.Image.FromStream(sourceImage.OpenReadStream());
            var image = ResizeImageOriginalRatio(souimage, 478, 595);
            filename = UploadFile(image, urlPath);

            return filename;
        }

        public static string UploadMediumFile(IFormFile sourceImage, string urlPath)
        {
            string filename = string.Empty;
            System.Drawing.Image souimage =
                System.Drawing.Image.FromStream(sourceImage.OpenReadStream());
            var image = ResizeImageOriginalRatio(souimage, 368, 349);
            filename = UploadFile(image, urlPath);
            return filename;
        }

        //public static string UploadMediumFile(IFormFile file, int width, int height, string urlPath)
        //{
        //    var image = Image.FromStream(file.OpenReadStream());
        //    var imageBytes = ResizeImageOriginalRatio(image, width, height);
        //    return UploadFile(imageBytes, urlPath);
        //}

        //public static string UploadSmallFile(IFormFile file, int width, int height, string urlPath)
        //{
        //    var image = Image.FromStream(file.OpenReadStream());
        //    var imageBytes = ResizeImageOriginalRatio(image, width, height);
        //    return UploadFile(imageBytes, urlPath);
        //}
        public static string UploadSmallFile(IFormFile sourceImage, string urlPath)
        {
            string fileName = string.Empty;
            System.Drawing.Image souimage =
                System.Drawing.Image.FromStream(sourceImage.OpenReadStream());
            var image = ResizeImageOriginalRatio(souimage, 208, 183);
            fileName = UploadFile(image, urlPath);
            return fileName;
        }
        public static string UploadFile(byte[] imageBytes, string urlPath)
        {

            string filename = string.Empty;
            filename = GetFileName();
            string MonthDate = DateTime.UtcNow.ToString("MMMM-yyyy");
            string customUrl = WebHostHelper.baseUrl + "/" + urlPath + "/" + MonthDate + "/";
            string fileUrl = urlPath + "/" + MonthDate + "/";
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), customUrl);
            var path = Path.Combine(Directory.GetCurrentDirectory(), customUrl, filename);
            if (!Directory.Exists(basePath))
            {
                DirectoryInfo di = Directory.CreateDirectory(basePath);
            }
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write, 4096))
            {
                stream.Write(imageBytes, 0, imageBytes.Length);
            }
            filename = fileUrl + filename;
            return filename;

        }
    
        public static byte[] ResizeImageOriginalRatio(Image image, int width, int height)
        {
            //if (image.Width > image.Height)
            //{
            //    width = width > height ? width : height;
            //    height = width < height ? width : height;
            //}
            var resized = new Bitmap(image, new Size(width, height));
            using var imageStream = new MemoryStream();
            resized.Save(imageStream, ImageFormat.Jpeg);
            var imageBytes = imageStream.ToArray();
            return imageBytes;
        }
        private static string GetFileName()
        {
            string extension = ".jpg";
            string fileName = Path.ChangeExtension(
                Path.GetRandomFileName(),
                extension
            );
            return fileName;
        }
        private static string GetFileName(string extension)
        {
            string fileName = Path.ChangeExtension(
                Path.GetRandomFileName(),
                extension
            );
            return fileName;
        }
        public static string GetExtension(string attachment_name)
        {
            var index_point = attachment_name.IndexOf(".") + 1;
            return attachment_name.Substring(index_point);
        }
    }
}
