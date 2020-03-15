using System;

namespace BlogSystem.Dtos
{
    public class FriendLinkDto
    {
        public Guid Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Title { get; set; }

        public string Link { get; set; }
    }
}