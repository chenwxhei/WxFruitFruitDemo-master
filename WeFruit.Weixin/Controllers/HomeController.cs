using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFruit.EFModels;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class HomeController : Controller
    {
        HomeViewModel homeViewModel = new HomeViewModel();
        public IBannerService BannerService { get; set; }

        public INoticeService NoticeService { get; set; }

        public IProductService ProductService { get; set; }

        public ActionResult Index(int proid=1)
        {
            homeViewModel.NoticeNum = NoticeService.GetCount(n => true);
            homeViewModel.Banners = BannerService.GetEntities(b => true);
            homeViewModel.Notices = NoticeService.GetEntitiesByPage(3, 1, false, m => true, m => m.ModiTime);
            homeViewModel.Products = ProductService.GetEntitiesByPage(3, 1, false, p => p.Type == proid, p => p.Moditime);
            homeViewModel.Proid = proid;
            homeViewModel.OAuthUserInfos = Session["userinfo"] as OAuthUserInfo;
            return View(homeViewModel);
        }

        public ActionResult Notice()
        {
            homeViewModel.Notices = NoticeService.GetEntities(b => true);
            return View(homeViewModel);
        }

        public ActionResult Notice_xq(int id)
        {
            homeViewModel.Notices = NoticeService.GetEntities(b => b.Id == id);
            return View(homeViewModel);
        }
    }
}