using System;

namespace BlogSystem.Dtos
{
    public class CopyrightDto
    {
        public Guid Id { get; set; }
        public DateTime UpdateTime { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Logo { get; set; }

        public string Images { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string QQNumber { get; set; }

        public string QQNumber2 { get; set; }

        public string Wechat { get; set; }
    }
}