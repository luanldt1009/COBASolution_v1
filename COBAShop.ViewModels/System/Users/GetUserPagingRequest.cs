using COBAShop.ViewModels.Comon;
using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}