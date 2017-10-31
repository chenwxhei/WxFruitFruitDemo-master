using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Helpers;

namespace WeFruit.Weixin.Controllers
{
    public class OAuthController : Controller
    {
        private string _appId = "wx7ae3369676c48a81";
        private string _appsecret = "cf8989a7187e2b81ae24551ebf1c52ae";
        private string _domin = "http://wx.lfacr.top";

        // GET: OAuth
        public ActionResult Login(string requestUrl)
        {
            var redrectUrl = $"{_domin}{Url.Action("CallBack", new { requestUrl })}";

            var state = "wx" + DateTime.Now.Millisecond;
            Session["state"] = state;
            var url = OAuthApi.GetAuthorizeUrl(_appId, redrectUrl, state, OAuthScope.snsapi_base);
            return Redirect(url);
        }
        /// <summary>
        /// 这是微信授权完成，所执行的回调方法
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="reqestUrl"></param>
        /// <returns></returns>
        public ActionResult CallBack(string code, string state, string requestUrl)
        {
            if (state != (string)Session["state"])
            {
                return Content("非法访问！");
            }
            if (string.IsNullOrEmpty(code))
            {
                return Content("授权失败!");
            }

            var oAuthAccessToken = OAuthApi.GetAccessToken(_appId, _appsecret, code);

            if (oAuthAccessToken.errcode != ReturnCode.请求成功)
            {
                return Content("授权失败！");
            }

            Session["AccessToken"] = oAuthAccessToken;

            try
            {
                var userinfo = OAuthApi.GetUserInfo(oAuthAccessToken.access_token, oAuthAccessToken.openid);
                Session["userinfo"] = userinfo;

                return Redirect(requestUrl);
            }
            catch (Exception)
            {
                var redrectUrl = $"{_domin}{Url.Action("CallBack", new { requestUrl })}";

                var url = OAuthApi.GetAuthorizeUrl(_appId, redrectUrl, state, OAuthScope.snsapi_userinfo);
                return Redirect(url);
            }


        }

        public ActionResult JsSdkConfig()
        {
            //生成需要注册的完整URl（包含前缀和域名）
            var url = _domin + Request.RawUrl;
            //获取js SDK的配置信息
            var config = JSSDKHelper.GetJsSdkUiPackage(_appId, _appsecret, url);
            return PartialView(config);
        }
    }
}