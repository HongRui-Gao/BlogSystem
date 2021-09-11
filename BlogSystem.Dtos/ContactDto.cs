using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Dtos
{
    public class ContactDto 
    {

        public Guid Id { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string UpdateTime { get; set; }
    }
}
