using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class ProdetailController : Controller
    {
        public IProductService ProductService { get; set; }
        public ActionResult Index()
        {
            //HomeViewModel homeViewModel = new HomeViewModel();
            //homeViewModel.Products = ProductService.GetEntities(b => b.Code == procode);
            return View();
        }
    }
}