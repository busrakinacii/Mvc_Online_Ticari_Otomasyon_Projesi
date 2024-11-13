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
            var pro = co.Products.Where(x => x.ProductStatus == true).ToList();
            return View(pro);
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> listValue = (from x in co.Categories.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryId.ToString()
                                              }).ToList();
            ViewBag.Val = listValue;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            var pro = co.Products.Add(p);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var value = co.Products.Find(id);
            value.ProductStatus = false;
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}