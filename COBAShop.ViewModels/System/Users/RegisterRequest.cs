using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COBAShop.ViewModels.System.Users
{
    public class RegisterRequest
    {
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Tên là trường bắt buộc")]
        public string FirstName { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Họ là trường bắt buộc")]
        public string LastName { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh là trường bắt buộc")]
        public DateTime Dob { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email là trường bắt buộc")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu là trường bắt buộc")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Xác nhận mật khẩu là trường bắt buộc")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}