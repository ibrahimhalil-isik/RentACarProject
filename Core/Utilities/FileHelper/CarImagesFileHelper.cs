using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class CarImagesFileHelper
    {
        public static string Add(IFormFile formFile)
        {
            string extension = Path.GetExtension(formFile.FileName).ToUpper();
            string newGuid = CreateGuid() + extension;
            var directory = Directory.GetCurrentDirectory() + "\\wwwroot";
            var path = directory + @"\Images";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string imagePath;
            using (FileStream fileStream = File.Create(path + "\\" + newGuid))
            {
                formFile.CopyTo(fileStream);
                imagePath = path + "\\" + newGuid;
                fileStream.Flush();
            }
            return newGuid;
        }
        public static void Update(IFormFile formFile, string OldPath)
        {
            string extension = Path.GetExtension(formFile.FileName).ToUpper();
            using (FileStream fileStream = File.Open(OldPath.Replace("/", "\\"), FileMode.Open))
            {
                formFile.CopyToAsync(fileStream);
                fileStream.Flush();
            }
        }
        public static void Delete(string ImagePath)
        {
            if (File.Exists(ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath) != "default.png")
            {
                File.Delete(ImagePath.Replace("/", "\\"));
            }
        }

        private static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
        }
    }
}
