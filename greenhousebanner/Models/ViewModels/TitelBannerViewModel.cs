using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace greenhousebanner.Models.ViewModels
{
    public class TitelBannerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Vui lòng nhập tên tiêu đề.")]
        [MinLength(3, ErrorMessage = "Tên tiêu đề quá ngắn.")]
        [MaxLength(150, ErrorMessage = "Tên tiêu đề quá dài.")]
        public string Titel { get; set; }
    }
}