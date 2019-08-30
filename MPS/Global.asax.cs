using MPS.LogAttrubite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MPS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~") + @"\log4net.config"));
            GlobalConfiguration.Configuration.Filters.Add(new WebApiExceptionFilterAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new ActionFilter());
        }
    }
}
