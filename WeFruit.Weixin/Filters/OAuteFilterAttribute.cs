using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeFruit.Weixin.Filters
{
    public class OAuteFilterAttribute:FilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["AccessToken"] != null) return;

            var requestUrl = filterContext.HttpContext.Request.RawUrl;

            var urHelper = new UrlHelper(filterContext.RequestContext);

            filterContext.Result = new RedirectResult(urHelper.Action("Login", "OAuth", new { requestUrl }));
        }
    }
}