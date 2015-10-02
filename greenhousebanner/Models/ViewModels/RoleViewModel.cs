using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace greenhousebanner.Models.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên quyền")]
        [MaxLength(100, ErrorMessage = "Tên quyền không quá 100 kí tự")]
        [MinLength(1, ErrorMessage = "Tên quyền quá ngắn.")]
        public string RoleName { get; set; }
    }
}