using COBAShop.Data.Entities;
using COBAShop.ViewModels.Comon;
using COBAShop.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.Service.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}