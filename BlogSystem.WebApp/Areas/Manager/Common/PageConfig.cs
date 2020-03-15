using System.Configuration;

namespace BlogSystem.WebApp.Areas.Manager.Common
{
    public class PageConfig
    {
        //获取每页展示多少条的方法
        public static int GetPageSize()
        {
            return int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        }

        /// <summary>
        /// 获取可以分页的总数
        /// </summary>
        /// <param name="count">数据的总条数</param>
        /// <returns>能分的页数</returns>
        public static int GetTotalPage(int count)
        {
            return count % GetPageSize() == 0 ? count / GetPageSize() : count / GetPageSize() + 1;
        }
    }
}