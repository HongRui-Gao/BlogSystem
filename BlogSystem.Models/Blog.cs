using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Blog : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "博客名称")]
        public string Title { get; set; }


        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(2000), Column(TypeName = "text")]
        [Display(Name = "博客内容")]
        public string Content { get; set; }

        
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "博客图片")]
        public string Images { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "博客作者")]
        public string Author { get; set; }


    }
}
