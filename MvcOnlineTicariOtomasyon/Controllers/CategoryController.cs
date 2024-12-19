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
    }
}