using Phidelis.Core.MEF;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Plugins
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            PluginManager.Instance().Initialize(Server.MapPath("~/bin"));
        }
    }
}
