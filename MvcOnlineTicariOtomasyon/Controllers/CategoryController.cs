using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context co = new Context();
        public ActionResult Index(int page = 1)
        {
            var values = co.Categories.ToList().ToPagedList(page, 4);
            return View(values);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category c)
        {
            co.Categories.Add(c);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var ctg = co.Categories.Find(id);
            co.Categories.Remove(ctg);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryEdit(int id)
        {
            var ctg = co.Categories.Find(id);
            return View("CategoryEdit", ctg);
        }

        public ActionResult CategoryUpdate(Category c)
        {
            var ctg = co.Categories.Find(c.CategoryId);
            ctg.CategoryName = c.CategoryName;
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Test()
        {
            Class2 cs = new Class2();
            cs.Categories = new SelectList(co.Categories, "CategoryId", "CategoryName");
            cs.Products = new SelectList(co.Products, "ProductId", "ProductName");
            return View(cs);
        }

        //json Deger olarak Kategoriye göre seçilen ürünleri listeleme işlem yaptık.
        // Asp.Net Mvc5 ile Online Ticari Otomasyon dersi video 247

        public JsonResult ProductBring(int p)
        {
            var productList = (from x in co.Products
                               join y in co.Categories
                               on x.Category.CategoryId equals y.CategoryId
                               where x.Category.CategoryId == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductId.ToString()
                               }).ToList();
            return Json(productList,JsonRequestBehavior.AllowGet);
        }
    }
}