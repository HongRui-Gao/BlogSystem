using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class Roles : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "权限名称")]
        public string Title { get; set; }
    }
}