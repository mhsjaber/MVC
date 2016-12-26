using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception lastErrorInfo = Server.GetLastError();
            Exception errorInfo = null;

            bool isNotFuund = false;
            if (lastErrorInfo != null)
            {
                errorInfo = lastErrorInfo.GetBaseException();
                var error = errorInfo as HttpException;
                if (error != null)
                    isNotFuund = error.GetHttpCode() == (int)HttpStatusCode.NotFound;
            }
            if (isNotFuund)
            {
                Server.ClearError();
                Response.Redirect("~/HttpError/Error404");// Do what you need to render in view
            }
        }
    }
}
