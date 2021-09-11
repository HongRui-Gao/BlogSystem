using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class Contact : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "邮件地址")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "联系地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "联系电话")]
        public string Tel { get; set; }

    }
}
