using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.WebApp.Areas.Manager.Data.Category
{
    public class CategoryListViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string  Details { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}