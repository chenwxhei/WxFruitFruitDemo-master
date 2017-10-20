using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class ClassifyController : Controller
    {
        public ISortService SortService { get; set; }
        public ActionResult Index()
        {
            HomeViewModel homeViewModel=new HomeViewModel();
            homeViewModel.Sorts = SortService.GetEntities(b => true);
            return View(homeViewModel);
        }
    }
}