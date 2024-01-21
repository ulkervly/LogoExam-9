using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Business.Extensions
{
    public static class FileManager
    {
        public static string SaveFile(this IFormFile file ,string rootPath,string folderName)
        {
            var fileName = file.FileName.Length > 64 ?
              file.FileName.Substring(file.FileName.Length-64,64): file.FileName;
            fileName = Guid.NewGuid().ToString() + fileName;
            string path = Path.Combine(rootPath, fileName,folderName);
            using (FileStream stream=new FileStream(path,FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;    
        }
        public static void DeleteFile(string rootPath, string folderName,string ImageUrl)
        {
            if (File.Exists(rootPath))
            {
                File.Delete(rootPath);
            }
        }
    }
}
