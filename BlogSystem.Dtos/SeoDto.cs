using System;

namespace BlogSystem.Dtos
{
    public class SeoDto
    {
        public Guid Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public Guid WebMenuId { get; set; }

     
    }
}