using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace greenhousebanner.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản.")]
        [MaxLength(200, ErrorMessage = "Tên tài khoản không lớn hơn 200 ký tự!")]
        [MinLength(3, ErrorMessage = "Độ dài tên tài khoản không hợp lệ!")]
        [RegularExpression(@"^(?:[\p{L}]+\s?)+$", ErrorMessage = "Tên không được chứa ký tự đặc biệt!")]      
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [MaxLength(200, ErrorMessage = "Chiều dài mật khẩu không lớn hơn 200 ký tự!")]
        [MinLength(3, ErrorMessage = "Mật khẩu quá ngắn!")]
        public string Password { get; set; }
        public string OldPassword { get; set; }

        [System.Web.Mvc.Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn quyền.")]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
        [MaxLength(200, ErrorMessage = "Tên không lớn hơn 200 ký tự!")]
        [MinLength(3, ErrorMessage = "Độ dài tên không hợp lệ!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        public string Email { get; set; }
    }
}