using Core.Utilities.Helper.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extensions = Path.GetExtension(file.FileName);
                string guid = GuidHelperManager.CreateGuid();
                string filePath = guid + extensions;

                using (FileStream fileStream = File.Create(root+filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();//ara bellekten siler.
                    return filePath;
                }
            }
            return null;
        }
    }
}
