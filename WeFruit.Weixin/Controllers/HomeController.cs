using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFruit.EFModels;
using WeFruit.IService;
using WeFruit.Weixin.Filters;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    //[OAuteFilter]//授权登陆
    public class HomeController : Controller
    {
        HomeViewModel homeViewModel = new HomeViewModel();
        public IBannerService BannerService { get; set; }

        public INoticeService NoticeService { get; set; }

        public IProductService ProductService { get; set; }

        public ICustomerService CustomerService { get; set; }

        
       

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public ActionResult Index(int proid=1)
        {
            homeViewModel.NoticeNum = NoticeService.GetCount(n => true);//公告个数
            homeViewModel.Banners = BannerService.GetEntities(b => true);//banner
            homeViewModel.Notices = NoticeService.GetEntitiesByPage(3, 1, false, m => true, m => m.ModiTime);//公告
            homeViewModel.Products = ProductService.GetEntitiesByPage(3, 1, false, p => p.Type == proid, p => p.Moditime);//商品
            homeViewModel.Proid = proid;//热销，推荐，限时
            //addCus(Session["userinfo"] as OAuthUserInfo);//授权登陆
            Session["usid"] = 2;
            return View(homeViewModel);
        }
        /// <summary>
        /// 公告列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult Notice()
        {
            homeViewModel.Notices = NoticeService.GetEntities(b => true);
            return View(homeViewModel);
        }
        /// <summary>
        /// 公告详情页
        /// </summary>
        /// <param name="id">公告id</param>
        /// <returns></returns>
        public ActionResult Notice_xq(int id)
        {
            homeViewModel.Notices = NoticeService.GetEntities(b => b.Id == id);
            return View(homeViewModel);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="cusid"></param>
        public void addCus(OAuthUserInfo cusid)
        {
            Customer cust = new Customer();
            cust.OpenId = cusid.openid;
            cust.Name = cusid.nickname;
            cust.Img = cusid.headimgurl;
            cust.Address = cusid.city;
            cust.CreateTime=DateTime.Now;
            
            if (CustomerService.GetEntities(b=>b.OpenId==cusid.openid).Count()<=0)
            {
                CustomerService.Add(cust);
            }
            else if(CustomerService.GetEntities(b => b.OpenId == cusid.openid&&b.Name==cusid.nickname&&b.Img==cusid.headimgurl).Count() <= 0)
            {
                CustomerService.Modity(cust);
            }
            //Session["usid"]=CustomerService.GetEntity(b=>b.OpenId==cust.OpenId).Id;//当前登录用户id
            
        }
    }
}