using COBAShop.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.Service.Utilities.Slides
{
    public interface ISliderService
    {
        Task<List<SlideVm>> GetAll();
    }
}