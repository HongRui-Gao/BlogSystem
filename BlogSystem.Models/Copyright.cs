using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class Copyright : BaseEntity
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "版权名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "版权描述")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "版权座机")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "版权移动电话")]
        public string Mobile { get; set; }


        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "版权Logo图片")]
        public string Logo { get; set; }


        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "版权图片")]
        public string Images { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "联系地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "QQ号码1")]
        public string QQNumber { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "QQ号码2")]
        public string QQNumber2 { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "微信号")]
        public string Wechat { get; set; }
    }
}