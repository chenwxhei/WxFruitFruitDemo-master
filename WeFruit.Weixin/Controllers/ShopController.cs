using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using WeFruit.EFModels;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class ShopController : Controller
    {
        HomeViewModel homeViewModel=new HomeViewModel();

        public IShopCartService ShopCartService { get; set; }

        //public IProductService ProductService { get; set; }
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShopCar()
        {
            homeViewModel.ShoppingCarts = ShopCartService.GetEntities(b =>b.CusId==Convert.ToInt32(Session["usid"]) );//查询购物车
            return View(homeViewModel);
        }
        /// <summary>
        /// 修改商品数量
        /// </summary>
        public void Shopqty()
        {
            string aa = Session["usid"].ToString();
            string bb = Request["procode"];
            var car = ShopCartService.GetEntity(b => b.CusId == Convert.ToInt32(Session["usid"]) && b.ProCode == Request["procode"]);//查询要修改的
            car.Qty = Convert.ToInt32(Request["qty"]);
            ShopCartService.Modity(car);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        public void Shopdatle()
        {
            int aa =Convert.ToInt32(Session["usid"]);
            string bb = Request["procode"];
            var car = ShopCartService.GetEntity(b => b.CusId == aa && b.ProCode == bb);
            ShopCartService.Romove(car);
        }
    }
}