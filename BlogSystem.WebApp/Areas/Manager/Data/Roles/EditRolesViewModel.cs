using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BlogSystem.WebApp.Areas.Manager.Data.Roles
{
    public class EditRolesViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "权限名称")]
        [Remote("CheckRolesTitle", "RolesManager", ErrorMessage = "该权限名称已存在")]
        public string Title { get; set; }


        

    }
}