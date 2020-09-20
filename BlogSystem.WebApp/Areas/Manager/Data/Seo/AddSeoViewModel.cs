using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.WebApp.Areas.Manager.Data.Seo
{
    public class AddSeoViewModel
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "优化名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "优化关键字")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "优化描述")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "优化网站菜单名称")]
        public Guid WebMenuId { get; set; }
    }
}