using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class WebMenu : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "网站菜单名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "网站菜单连接")]
        public string Link { get; set; }

        
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "网站菜单图标")]
        public string Icon { get; set; }

        

        [Display(Name = "网站菜单等级")]
        public Guid ParentId { get; set; }
    }
}