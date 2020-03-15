using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class FriendLink : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "友情链接名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "友情链接地址")]
        public string Link { get; set; }
    }
}