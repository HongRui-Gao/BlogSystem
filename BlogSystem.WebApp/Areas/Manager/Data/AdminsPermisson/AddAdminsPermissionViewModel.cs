using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.WebApp.Areas.Manager.Data.AdminsPermisson
{
    public class AddAdminsPermissionViewModel
    {
        [Required]
        public Guid RolesId { get; set; }
        [Required]
        public Guid[] SystemMenuId { get; set; }
    }
}