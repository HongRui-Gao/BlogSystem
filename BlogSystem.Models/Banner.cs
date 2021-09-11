using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Banner : BaseEntity
    {
        [Required(ErrorMessage ="{0}不能为空")]
        [StringLength(50),Column(TypeName ="nvarchar")]
        [Display(Name ="轮播图片名称")]
        public string Title { get; set; }


        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "轮播图片路径")]
        public string Images { get; set; }
    }
}
