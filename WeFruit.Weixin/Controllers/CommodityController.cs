using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class CommodityController : Controller
    {
        public IProductService ProductService { get; set; }
        public ActionResult Index(int code)
        {
            HomeViewModel homeViewModel=new HomeViewModel();
            homeViewModel.Products = ProductService.GetEntities(b => b.Sorts.First().Code == code);
            return View(homeViewModel);
        }
    }
}