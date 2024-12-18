using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CargoManagementApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SwaggerConfig.Register(); // Register Swagger
            UnityConfig.RegisterComponents(); // Register Unity
        }
    }
}
