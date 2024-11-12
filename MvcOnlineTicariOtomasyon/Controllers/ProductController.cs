using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context co = new Context();
        public ActionResult Index()
        {
            var pro = co.Products.ToList();
            return View(pro);
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            var pro = co.Products.Add(p);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}