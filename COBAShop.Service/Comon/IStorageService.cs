using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.Service.Comon
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream stream, string fileName);

        Task DeteleFileAsync(string fileName);
    }
}