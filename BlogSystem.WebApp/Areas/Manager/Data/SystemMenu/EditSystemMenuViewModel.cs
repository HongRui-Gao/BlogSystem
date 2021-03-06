﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogSystem.WebApp.Areas.Manager.Data.SystemMenu
{
    public class EditSystemMenuViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "系统菜单名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "系统菜单连接")]
        public string Link { get; set; }

        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "系统菜单图标")]
        public string Icon { get; set; }


        [Display(Name = "系统菜单等级")]
        public Guid ParentId { get; set; }
    }
}