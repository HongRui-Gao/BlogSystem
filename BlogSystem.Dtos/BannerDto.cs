using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Dtos
{
    public class BannerDto
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Images { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
