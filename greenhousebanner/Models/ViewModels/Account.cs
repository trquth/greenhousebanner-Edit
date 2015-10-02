using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace greenhousebanner.Models.ViewModels
{
    public class Account
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}