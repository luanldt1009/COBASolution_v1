using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COBAShop.ViewModels.Catalog.Categories
{
    public class CategoryVm
    {
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
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
        public int SortOrder { get; set; }

        [Display(Name = "Cho phép hiển thị")]
        public bool IsShowOnHome { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        public string StatusName
        {
            get
            {
                if (Status == 0)
                    return "Khóa";
                else
                    return "Hoạt động";
            }
        }
    }
}