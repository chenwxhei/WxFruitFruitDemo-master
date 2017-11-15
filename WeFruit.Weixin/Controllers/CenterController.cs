using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class CenterController : Controller
    {
        HomeViewModel homeViewModel = new HomeViewModel();

        public ICustomerService CustomerService { get; set; }
        //用户信息首页
        public ActionResult Index()
        {
            homeViewModel.Customers = CustomerService.GetEntity(b=>b.Id== Convert.ToInt32(Session["usid"]));
            return View(homeViewModel);
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