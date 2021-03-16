using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COBAShop.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Sản phẩm là trường bắt buộc")]
        public string Name { get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán là trường bắt buộc")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Số lượng là bắt buộc nhập")]
        public int Stock { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Chi tiết")]
        public string Details { get; set; }

        [Display(Name = "Mô tả SEO (Tối đa 155)")]
        public string SeoDescription { get; set; }

        [Display(Name = "Tiêu đề SEO")]
        public string SeoTitle { get; set; }

        public string LanguageId { get; set; }

        public IFormFile ThumbnailImage { get; set; }
    }
}