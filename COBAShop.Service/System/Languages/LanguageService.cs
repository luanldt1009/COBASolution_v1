using COBAShop.Data.EF;
using COBAShop.ViewModels.Comon;
using COBAShop.ViewModels.System.Languages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.Service.System.Languages
{
    public class LanguageService : ILanguageService
    {
        public readonly COBAShopDbContext _context;

        public LanguageService(COBAShopDbContext context)
        {
            this._context = context;
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVm()
            {
                Id = x.Id,
                Name = x.Name,
                IsDefault = x.IsDefault
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}