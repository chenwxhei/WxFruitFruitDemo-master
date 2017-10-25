using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class ProductController : Controller
    {
        HomeViewModel homeViewModel =new HomeViewModel();
        // GET: Product
        public ActionResult Index(string code)
        {
            homeViewModel.Products = ProductService.GetEntities(b => b.Code == code);
            return View(homeViewModel);
        }

        public ISortService SortService { get; set; }
        public ActionResult Classify()
        {
            homeViewModel.Sorts = SortService.GetEntities(b => true);
            return View(homeViewModel);
        }

        public IProductService ProductService { get; set; }

        public ActionResult Commodity(string code)
        {
            if (SortService.GetCount(b=>b.Code==code)==0)
            {
                homeViewModel.Products = ProductService.GetEntities(b => b.Name.Contains(code));
            }
            else
            {
                homeViewModel.Products = ProductService.GetEntities(b => b.Sorts.First().Code == code);
            }
            return View(homeViewModel);
        }

        public ViewResult Search()
        {
            //homeViewModel.Products = ProductService.GetEntities(b => b.Name=code);
            return View();
        }
    }
}