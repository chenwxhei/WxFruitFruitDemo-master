using System;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using WeFruit.EFModels;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class ProductController : Controller
    {
        private readonly HomeViewModel homeViewModel = new HomeViewModel();

        public ISortService SortService { get; set; }

        public IProductService ProductService { get; set; }
        
        public IShopCartService ShopCartService { get; set; }

        public ActionResult Index(string code)
        {
            homeViewModel.Products = ProductService.GetEntities(b => b.Code == code);
            return View(homeViewModel);
        }

        public ActionResult Classify()
        {
            homeViewModel.Sorts = SortService.GetEntities(b => true);
            return View(homeViewModel);
        }

        public ActionResult Commodity(string code)
        {
            if (SortService.GetCount(b => b.Code == code) == 0)
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
            return View();
        }


        public void Insert()
        {
            ShoppingCart shoppingCart=new ShoppingCart();
            string aa = Request["code"];
            shoppingCart.ProCode = aa;//商品ID
            shoppingCart.Qty= Convert.ToInt32(Request["qty"]);//商品数量
            int bb = Convert.ToInt32(Session["usid"]);
            shoppingCart.CusId=bb;//用户ID
            shoppingCart.CreateTime=DateTime.Now;//时间
            if (ShopCartService.GetEntities(b => b.ProCode == Request["code"]).Count()<=0)//查询数据库是否存在该商品
            {
                ShopCartService.Add(shoppingCart);
                Response.Write("200");
            }
            else
            {
                var pro = ShopCartService.GetEntity(b => b.ProCode == Request["code"]);//查询单条数据
                pro.Qty += Convert.ToInt32(Request["qty"]);
                ShopCartService.Modity(pro);
                Response.Write("500");
            }
        }
    }
}