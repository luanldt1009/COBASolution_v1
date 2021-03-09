using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.Service.Comon
{
    public class StorageService : IStorageService
    {
        private readonly string _userContentFolder;
        public const string USER_CONTENT_FOLDER_NAME = "user-content";

        public StorageService(IHostingEnvironment env)
        {
            _userContentFolder = Path.Combine(env.WebRootPath, USER_CONTENT_FOLDER_NAME);
        }

        public async Task DeteleFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream stream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            var output = new FileStream(filePath, FileMode.Create);
            await stream.CopyToAsync(output);
        }
    }
}