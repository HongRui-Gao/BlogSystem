using System.Collections.Generic;

namespace BlogSystem.WebApp.Areas.Manager.Data.LeftMenu
{
    public class LeftMenuListViewModel
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public List<LeftMenuListViewModel> SonList { get; set; } = new List<LeftMenuListViewModel>();
    }
}