using System.Web;
using System.Web.Mvc;

namespace CodeStudy.UI.EasyUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
