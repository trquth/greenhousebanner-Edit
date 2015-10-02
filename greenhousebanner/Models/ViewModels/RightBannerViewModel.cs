using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace greenhousebanner.Models.ViewModels
{
    public class RightBannerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đầy đủ thông tin.")]
        [MaxLength(150, ErrorMessage = "Tên không dài quá 150 kí tự.")]
        [MinLength(3, ErrorMessage = "Tên quá ngắn.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đầy đủ thông tin.")]
        [MaxLength(150, ErrorMessage = "Tên dự án không dài quá 150 kí tự.")]
        [MinLength(3, ErrorMessage = "Tên dự án quá ngắn.")]
        public string PlanName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đầy đủ thông tin.")]
        [MaxLength(150, ErrorMessage = "Tên đơn vị công tác không dài quá 150 kí tự.")]
        [MinLength(3, ErrorMessage = "Tên đơn vị công tác quá ngắn.")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đây đủ thông tin")]
        [MaxLength(500, ErrorMessage = "Link bài viết không hợp lệ.")]
        [MinLength(1, ErrorMessage = "Link bài viết không hợp lệ.")]
        public string Link { get; set; }
    }
}