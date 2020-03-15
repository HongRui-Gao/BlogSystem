using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class Seo : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "网站页面标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Seo优化关键字")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(2000)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Seo优化描述")]
        public string Description { get; set; }

        [ForeignKey(nameof(WebMenu))]
        public Guid WebMenuId { get; set; }

        public WebMenu WebMenu { get; set; }
    }
}