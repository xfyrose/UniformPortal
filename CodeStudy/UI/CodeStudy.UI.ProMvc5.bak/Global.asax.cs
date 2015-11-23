using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CodeStudy.UI.ProMvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static string AllModules { get; set; }

        protected void Application_Start()
        {
            //Database.SetInitializer(new MusicStoreDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpApplication httpApps = HttpContext.Current.ApplicationInstance;
            //Get List of modules in module collections
            HttpModuleCollection httpModuleCollections = httpApps.Modules;
            //Response.Write("Total Number Active HttpModule : " + httpModuleCollections.Count.ToString() + "</br>");
            //Response.Write("<b>List of Active Modules</b>" + "</br>");
            foreach (string activeModule in httpModuleCollections.AllKeys)
            {
                AllModules += activeModule + "<br/>";
                //Response.Write(activeModule + "</br>");
            }
        }
    }
}
