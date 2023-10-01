using MemoApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MemoApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(CacheConfig.Register);
            GlobalConfiguration.Configure(SettingCollectionConfig.Register);
            GlobalConfiguration.Configure(MessagingConfig.Register);
            GlobalConfiguration.Configure(SwaggerConfig.Register);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // startup settings.
            //HttpConfiguration config = new HttpConfiguration();
            //CacheConfig.Register(config);
            //SettingCollectionConfig.Register(config);
            //MessagingConfig.Register(config);
            //WebApiConfig.Register(config);
            //SwaggerConfig.Register(config);
        }
    }
}
