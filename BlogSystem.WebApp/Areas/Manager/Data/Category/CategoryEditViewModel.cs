using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.WebApp.Areas.Manager.Data.Category
{
    public class CategoryEditViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="{0}不能为空")]
        [Display(Name = "博客类别名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "类别描述")]
        public string Details { get; set; }
    }
}