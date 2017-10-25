using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeFruit.Weixin.Controllers
{
    public class CenterController : Controller
    {
        //用户信息首页
        public ActionResult Index()
        {
            return View();
        }
        //收藏页
        public ActionResult Collect()
        {
            return View();
        }
        //地址页
        public ActionResult Site()
        {
            return View();
        }
        //地址添加页
        public ActionResult Site_add()
        {
            return View();
        }
        //意见反馈页
        public ActionResult Feedback()
        {
            return View();
        }
        //关于我们
        public ActionResult Aboutus()
        {
            return View();
        }
        //设置中心
        public ActionResult Set()
        {
            return View();
        }
    }
}