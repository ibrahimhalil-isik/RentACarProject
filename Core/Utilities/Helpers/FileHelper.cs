using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string sourcePath = Path.GetTempFileName();
            string destFileNameForDb = CreateNewFilePathForDB(file);
            string destFileNameForLocalFolder = CreateNewFilePathForLocalFolder(destFileNameForDb);

            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Move(sourcePath, destFileNameForLocalFolder);
            return destFileNameForDb;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            string pathForDb = CreateNewFilePathForDB(file);
            string pathForFolder = CreateNewFilePathForLocalFolder(pathForDb);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(pathForFolder, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);
            return pathForDb;
        }

        public static string CreateNewFilePathForDB(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"Images\{newPath}";
            return result;
        }

        public static string CreateNewFilePathForLocalFolder(string pathForLocalFolder)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\" + pathForLocalFolder;
            return path;
        }
    }
}



















//using Core.Utilities.Results;
//using Core.Utilities.Results.Abstract;
//using Core.Utilities.Results.Concrete;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.IO;

//namespace Core.Utilities.Helpers
//{
//    public class FileHelper
//    {
//        public static string AddAsync(IFormFile file)
//        {
//            var result = newPath(file);

//            try
//            {
//                var sourcepath = Path.GetTempFileName();

//                using (var stream = new FileStream(sourcepath, FileMode.Create))
//                {
//                    file.CopyTo(stream);
//                }

//                File.Move(sourcepath, result.newPath);
//            }
//            catch (Exception exception)
//            {

//                return exception.Message;
//            }

//            return result.Path2;
//        }

//        public static string UpdateAsync(string sourcePath, IFormFile file)
//        {
//            var result = newPath(file);

//            try
//            {
//                using (var stream = new FileStream(result.newPath, FileMode.Create))
//                {
//                    file.CopyTo(stream);
//                }

//                File.Delete(sourcePath);
//            }
//            catch (Exception excepiton)
//            {
//                return excepiton.Message;
//            }

//            return result.Path2;
//        }

//        public static IResult DeleteAsync(string path)
//        {
//            try
//            {
//                File.Delete(path);
//            }
//            catch (Exception exception)
//            {
//                return new ErrorResult(exception.Message);
//            }

//            return new SuccessResult();
//        }

//        public static (string newPath, string Path2) newPath(IFormFile file)
//        {
//            FileInfo ff = new FileInfo(file.FileName);

//            string fileExtension = ff.Extension;

//            var creatingUniqueFilename = Guid.NewGuid().ToString("N") + fileExtension;

//            string result = $@"{Environment.CurrentDirectory + @"\wwwroot\Images"}\{creatingUniqueFilename}";

//            return (result, $"\\Images\\{creatingUniqueFilename}");
//        }
//    }
//}



















//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace Core.Utilities.FileHelper
//{
//    public class CarImagesFileHelper
//    {
//        public static string Add(IFormFile formFile)
//        {
//            string extension = Path.GetExtension(formFile.FileName).ToUpper();
//            string newGuid = CreateGuid() + extension;
//            var directory = Directory.GetCurrentDirectory() + "\\wwwroot";
//            var path = directory + @"\Images";
//            if (!Directory.Exists(path))
//            {
//                Directory.CreateDirectory(path);
//            }
//            string imagePath;
//            using (FileStream fileStream = File.Create(path + "\\" + newGuid))
//            {
//                formFile.CopyTo(fileStream);
//                imagePath = path + "\\" + newGuid;
//                fileStream.Flush();
//            }
//            return newGuid;
//        }
//        public static void Update(IFormFile formFile, string OldPath)
//        {
//            string extension = Path.GetExtension(formFile.FileName).ToUpper();
//            using (FileStream fileStream = File.Open(OldPath.Replace("/", "\\"), FileMode.Open))
//            {
//                formFile.CopyToAsync(fileStream);
//                fileStream.Flush();
//            }
//        }
//        public static void Delete(string ImagePath)
//        {
//            if (File.Exists(ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath) != "default.png")
//            {
//                File.Delete(ImagePath.Replace("/", "\\"));
//            }
//        }

//        private static string CreateGuid()
//        {
//            return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
//        }
//    }
//}
