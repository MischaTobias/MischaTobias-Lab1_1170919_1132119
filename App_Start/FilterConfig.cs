using System.Web;
using System.Web.Mvc;

namespace Lab1_1170919_1132119
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
