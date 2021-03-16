using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COBAShop.ViewModels.Catalog.Categories
{
    public class CategoryUpdateRequest
    {
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục là trường bắt buộc")]
        public string Name { get; set; }

        [Display(Name = "Danh mục cha")]
        public int? ParentId { get; set; }

        [Display(Name = "Mô tả SEO (Tối đa 155)")]
        public string SeoDescription { get; set; }

        [Display(Name = "Tiêu đề SEO")]
        public string SeoTitle { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public string LanguageId { get; set; }

        [Display(Name = "Số thứ tự")]
        [Required(ErrorMessage = "Số thứ tự là trường bắt buộc")]
        public int SortOrder { get; set; }

        [Display(Name = "Cho phép hiển thị")]
        [Required(ErrorMessage = "Cho phép hiển thị là trường bắt buộc")]
        public bool IsShowOnHome { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
    }
}