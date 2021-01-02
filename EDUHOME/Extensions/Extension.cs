using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Extensions
{
    public static class Extention
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }

        public static bool MaxSize(this IFormFile file, int kb)
        {
            return file.Length / 1024 <= kb;
        }

        public static async Task<string> SaveImgAsync(this IFormFile file, string root, string folder)
        {
            string path = root;
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string resultPath = Path.Combine(root, folder, fileName);

            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }

    public enum Roles
    {
        Admin,
        Member
    }
}
