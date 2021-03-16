using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.Data.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }
        public Product Product { get; set; }
    }
}