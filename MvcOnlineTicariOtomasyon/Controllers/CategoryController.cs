using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context co = new Context();
        public ActionResult Index()
        {
            var values = co.Categories.ToList();
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
    }
}