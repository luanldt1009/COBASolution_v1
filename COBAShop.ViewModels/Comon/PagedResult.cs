using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.ViewModels.Comon
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}