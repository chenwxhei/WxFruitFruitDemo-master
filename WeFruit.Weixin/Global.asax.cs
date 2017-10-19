using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WeFruit.Weixin.App_Start;

namespace WeFruit.Weixin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册依赖注入
            AutofacConfig.RegisterDenpendency();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
