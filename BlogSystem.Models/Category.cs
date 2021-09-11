using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "类别名称")]
        public string Title { get; set; }


        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200), Column(TypeName = "nvarchar")]
        [Display(Name = "类别介绍")]
        public string Details { get; set; }
    }
}
