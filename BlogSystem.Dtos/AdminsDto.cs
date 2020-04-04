using System;

namespace BlogSystem.Dtos
{
    public class AdminsDto
    {
        public Guid Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string NickName { get; set; }
        public string Photo { get; set; }
        public string Images { get; set; }

        public Guid RolesId { get; set; }
    }
}