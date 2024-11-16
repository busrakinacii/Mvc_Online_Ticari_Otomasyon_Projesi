using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context co = new Context();
        public ActionResult Index()
        {
            var values = co.Currents.Where(x => x.CurrentStatus == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CurrentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentAdd(Current c)
        {
            co.Currents.Add(c);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}