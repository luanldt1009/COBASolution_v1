using COBAShop.ViewModels.Comon;
using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; }
    }
}