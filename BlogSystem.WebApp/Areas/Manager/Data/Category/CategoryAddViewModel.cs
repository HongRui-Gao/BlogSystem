using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.WebApp.Areas.Manager.Data.Category
{
    public class CategoryAddViewModel
    {
        [Required(ErrorMessage ="{0}不能为空")]
        [Remote("ValidateTitle","CategoryManager",ErrorMessage ="该{0}已存在")]
        [Display(Name ="类别名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "类别描述")]
        public string Details { get; set; }

    }
}