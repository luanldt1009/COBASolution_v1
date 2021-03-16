using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COBAShop.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán là bắt buộc nhập")]
        public decimal Price { get; set; }

        [Display(Name = "Giá nhập")]
        [Required(ErrorMessage = "Giá nhập là bắt buộc nhập")]
        public decimal OriginalPrice { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Số lượng là bắt buộc nhập")]
        public int Stock { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc nhập")]
        public string Name { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public string LanguageId { get; set; }

        public bool? IsFeatured { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Chi tiết")]
        public string Details { get; set; }

        [Display(Name = "Mô tả SEO (Tối đa 155)")]
        public string SeoDescription { get; set; }

        [Display(Name = "Tiêu đề SEO")]
        public string SeoTitle { get; set; }

        public string SeoAlias { get; set; }

        [Display(Name = "Hình ảnh")]
        public List<IFormFile> ThumbnailImages { get; set; }
    }
}