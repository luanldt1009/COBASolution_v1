using COBAShop.ViewModels.Comon;
using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}