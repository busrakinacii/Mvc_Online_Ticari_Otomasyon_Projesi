using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context co = new Context();
        public ActionResult Index()
        {
            var values = co.SalesTransactions.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SalesAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SalesAdd(SalesTransaction s)
        {
            co.SalesTransactions.Add(s);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}