using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class BlogPermission : BaseEntity
    {
        [Required(ErrorMessage ="{0}不能为空")]
        [Display(Name ="类别编号")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "博客编号")]
        public Guid BlogId { get; set; }
    }
}
