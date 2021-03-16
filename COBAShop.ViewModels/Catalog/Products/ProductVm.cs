using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COBAShop.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public int Id { set; get; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán là bắt buộc nhập")]
        public decimal Price { set; get; }

        [Display(Name = "Giá nhập")]
        [Required(ErrorMessage = "Giá nhập là bắt buộc nhập")]
        public decimal OriginalPrice { set; get; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Số lượng là bắt buộc nhập")]
        public int Stock { set; get; }

        [Display(Name = "Lượt xem")]
        public int ViewCount { set; get; }

        public DateTime DateCreated { set; get; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc nhập")]
        public string Name { set; get; }

        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        [Display(Name = "Chi tiết")]
        public string Details { set; get; }

        [Display(Name = "Mô tả SEO (Tối đa 155)")]
        public string SeoDescription { set; get; }

        [Display(Name = "Tiêu đề SEO")]
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public string LanguageId { set; get; }

        public bool? IsFeatured { get; set; }

        public string ThumbnailImage { get; set; }

        public List<string> Categories { get; set; } = new List<string>();

        [Display(Name = "Hình ảnh")]
        public List<IFormFile> ThumbnailImages { get; set; }
    }
}