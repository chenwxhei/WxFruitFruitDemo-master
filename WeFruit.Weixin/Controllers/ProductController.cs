using System.Linq;
using System.Web.Mvc;
using WeFruit.IService;
using WeFruit.Weixin.Models;

namespace WeFruit.Weixin.Controllers
{
    public class ProductController : Controller
    {
        private readonly HomeViewModel homeViewModel = new HomeViewModel();

        public ISortService SortService { get; set; }

        public IProductService ProductService { get; set; }
        // GET: Product
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
    }
}