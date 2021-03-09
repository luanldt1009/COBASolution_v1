﻿using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.ViewModels.Catalog.ProductImages
{
    public class ProductImageVm
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
    }
}