using System.Web;
using System.Web.Mvc;

namespace EPluribusUnumEndpoint
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
