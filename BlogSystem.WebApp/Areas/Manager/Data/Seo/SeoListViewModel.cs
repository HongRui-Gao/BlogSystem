using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.WebApp.Areas.Manager.Data.Seo
{
    public class SeoListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public string WebMenuTitle { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}