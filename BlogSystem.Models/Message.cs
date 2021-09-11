using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class Message : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "联系人姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "邮件地址")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "联系电话")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200), Column(TypeName = "nvarchar")]
        [Display(Name = "信息内容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "邮件地址")]
        public bool IsRead { get; set; } = false;
    }
}
