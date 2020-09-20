using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.WebApp.Areas.Manager.Data.Copyright
{
    public class CopyrightViewModel
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