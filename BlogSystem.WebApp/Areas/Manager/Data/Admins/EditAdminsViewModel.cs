using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BlogSystem.WebApp.Areas.Manager.Data.Admins
{
    public class EditAdminsViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "昵称")]
        public string NickName { get; set; }


        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "头像")]
        public string Photo { get; set; }

        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "小头像")]
        public string Images { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "权限编号")]
        [ForeignKey(nameof(Roles))]
        public Guid RolesId { get; set; }
    }
}