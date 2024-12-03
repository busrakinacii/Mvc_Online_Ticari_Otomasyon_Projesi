using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context co = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var value = co.Products.Where(x => x.ProductId == 1).ToList();
            cs.Value1 = co.Products.Where(x => x.ProductId == 1).ToList();
            cs.Value2 = co.ProductDetails.Where(y => y.DetailID == 1).ToList();
            return View(cs);
        }
    }
}