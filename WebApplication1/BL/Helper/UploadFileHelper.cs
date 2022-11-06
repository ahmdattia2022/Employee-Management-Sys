using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace WebApplication1.BL.Helper
{
    public class UploadFileHelper
    {
        public static string SaveFile(IFormFile fileUrl, string FolderPath)
        {
            string FilePath = Directory.GetCurrentDirectory()+ "/wwwroot/Folder/" + FolderPath;
            string FileName = Guid.NewGuid() + Path.GetFileName(fileUrl.FileName);
            string finalPath = Path.Combine(FilePath, FileName);
            using (var stream = new FileStream(finalPath, FileMode.Create))
            {
                fileUrl.CopyTo(stream);
            }
            return FileName;
        }
        public static void RemoveFile(string folderName,String fileName)
        {
            string path = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + folderName + fileName;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
 