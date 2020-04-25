using System;

namespace BlogSystem.WebApp.Areas.Manager.Data.SystemMenu
{
    public class SystemMenuListViewModel
    {
        public Guid Id { get; set; }
        public DateTime UpdateTime { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }


        public string Icon { get; set; }

        public string ParentTitle { get; set; }
    }
}