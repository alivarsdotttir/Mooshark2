using Mooshark2.Handlers;
using System.Web;
using System.Web.Mvc;

namespace Mooshark2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Default implementation
            filters.Add(new HandleErrorAttribute());

            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}
