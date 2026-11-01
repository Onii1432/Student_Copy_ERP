
using System.Web.Mvc;
// using StandardMetals.WebApp.UserAccessDtl;

namespace StandardMetals.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           //  filters.Add(new UserAccessFilter());
        }
    }
}

