using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class AdminsPermission : BaseEntity
    {
        [ForeignKey(nameof(Roles))]
        public Guid RolesId { get; set; }

        public Roles Roles { get; set; }

        [ForeignKey(nameof(SystemMenu))]
        public Guid SystemMenuId { get; set; }

        public SystemMenu SystemMenu { get; set; }
    }
}