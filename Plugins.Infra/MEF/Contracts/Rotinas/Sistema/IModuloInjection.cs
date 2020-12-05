using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Infra.Contracts.Rotinas.Sistema
{
    public interface IModuloInjection
    {
        void Application_Start(System.Web.HttpApplication httpApplication);
        void Session_Start(System.Web.HttpApplication httpApplication);
        void Session_End(System.Web.HttpApplication httpApplication);
    }
}
