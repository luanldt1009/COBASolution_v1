using COBAShop.ViewModels.Comon;
using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.ViewModels.Catalog.Categories
{
    public class GetCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
    }
}