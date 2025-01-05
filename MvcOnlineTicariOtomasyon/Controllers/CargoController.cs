using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context co = new Context();
        public ActionResult Index(string p)
        {
            var cargos = from x in co.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                cargos = cargos.Where(y => y.TrackingCode.Contains(p));
            }
            return View(cargos.ToList());
        }
        [HttpGet]
        public ActionResult CargoAdd()
        {
            Random rnd = new Random();
            string[] character = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int k1, k2, k3;
            k1 = rnd.Next(0, character.Length);
            k2 = rnd.Next(0, character.Length);
            k3 = rnd.Next(0, character.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//10-->3 1 2 1 2 1 
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string code = s1.ToString() + character[k1] + s2.ToString() + character[k2] + s3.ToString() + character[k3];
            ViewBag.trackingCode = code;
            return View();
        }
        [HttpPost]
        public ActionResult CargoAdd(CargoDetail car)
        {
            co.CargoDetails.Add(car);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}