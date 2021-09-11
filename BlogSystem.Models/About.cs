using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class About : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "关于我们标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(2000), Column(TypeName = "text")]
        [Display(Name = "关于我们内容")]
        public string Content { get; set; }


        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "关于我们图片")]
        public string Images { get; set; }
    }
}
