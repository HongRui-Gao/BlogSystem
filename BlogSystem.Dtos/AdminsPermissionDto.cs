using System;

namespace BlogSystem.Dtos
{
    public class AdminsPermissionDto
    {

        public Guid Id { get; set; }
        public DateTime UpdateTime { get; set; }

        public Guid RolesId { get; set; }
       
        public Guid SystemMenuId { get; set; }

    }
}