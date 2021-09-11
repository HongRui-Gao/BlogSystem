using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Dtos
{
    public class BlogPermissionDto
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public Guid BlogId { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
