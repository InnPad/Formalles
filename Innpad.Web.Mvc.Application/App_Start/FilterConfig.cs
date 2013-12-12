using System.Web;
using System.Web.Mvc;

namespace Innpad.Web.Mvc.Application
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}