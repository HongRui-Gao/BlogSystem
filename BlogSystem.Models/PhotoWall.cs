using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class PhotoWall : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "图片名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100), Column(TypeName = "nvarchar")]
        [Display(Name = "图片描述")]
        public string Details { get; set; }


        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(50), Column(TypeName = "nvarchar")]
        [Display(Name = "图片路径")]
        public string Images { get; set; }



    }
}
