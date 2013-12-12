using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Formall.Web.Mvc.Application
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Occurs as the first event in the HTTP pipeline chain of execution when ASP.NET
        /// responds to a request.
        /// </summary>
        protected void Application_BeginRequest()
        {
            var authority = Request.Url.GetLeftPart(UriPartial.Authority);

            Schema.Initialize(authority);
        }

        /// <summary>
        /// Occurs as the last event in the HTTP pipeline chain of execution when ASP.NET
        /// responds to a request.
        /// </summary>
        protected void Application_EndRequest()
        {
            Schema.Finalize();
        }

        /// <summary>
        ///  Occurs just before ASP.NET performs any logging for the current request.
        /// </summary>
        protected void Application_LogRequest()
        {
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}