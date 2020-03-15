using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class Admins : BaseEntity
    {
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

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "头像")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "权限编号")]
        [ForeignKey(nameof(Roles))]
        public Guid RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}