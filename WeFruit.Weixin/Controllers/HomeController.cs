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
        public IBannerService BannerService { get; set; }

        public INoticeService NoticeService { get; set; }

        public IProductService ProductService { get; set; }

        public ActionResult Index()
        {
            HomeViewModel homeViewModel=new HomeViewModel();
            homeViewModel.NoticeNum = NoticeService.GetCount(n => true);
            homeViewModel.Banners = BannerService.GetEntities(b => true);
            homeViewModel.Notices = NoticeService.GetEntitiesByPage(3, 1, false, m => true, m => m.ModiTime);
            homeViewModel.Products = ProductService.GetEntitiesByPage(3, 1, false, p => p.Type == 1, p => p.Moditime);
            return View(homeViewModel);
        }
    }
}