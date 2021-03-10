using COBAShop.Data.EF;

using COBAShop.ViewModels.Utilities.Slides;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.Service.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        public readonly COBAShopDbContext _context;

        public SlideService(COBAShopDbContext context)
        {
            this._context = context;
        }

        public async Task<List<SlideVm>> GetAll()
        {
            var slides = await _context.Slides.OrderBy(x => x.SortOrder).Select(x => new SlideVm()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Url = x.Url,
                Image = x.Image,
            }).ToListAsync();
            return slides;
        }
    }
}