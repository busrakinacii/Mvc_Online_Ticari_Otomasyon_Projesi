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
            c.CurrentStatus = true;
            co.Currents.Add(c);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDelete(int id)
        {
            var cr = co.Currents.Find(id);
            cr.CurrentStatus = false;
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentEdit(int id)
        {
            var cr = co.Currents.Find(id);
            return View("CurrentEdit", cr);
        }

        public ActionResult CurrentUpdate(Current c)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrentEdit");
            }
            var crr = co.Currents.Find(c.CurrentId);
            crr.CurrentName = c.CurrentName;
            crr.CurrentSurname = c.CurrentSurname;
            crr.CurrentMail = c.CurrentMail;
            crr.CurrentCity = c.CurrentCity;
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSales(int id)
        {
            var values = co.SalesTransactions.Where(x => x.CurrentID == id).ToList();
            var cr = co.Currents.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.crrnt= cr;
            return View(values);
        }

    }
}