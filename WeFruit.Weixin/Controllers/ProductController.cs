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
        HomeViewModel homeViewModel = new HomeViewModel();
        // GET: Product
        public ActionResult Index()
        {
            return View();
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
            var Products = ProductService.GetEntities(b => b.Sorts.First().Code == code);
            return View(Products);
        }
    }
}