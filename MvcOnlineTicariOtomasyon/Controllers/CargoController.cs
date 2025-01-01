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
        public ActionResult Index()
        {
            var cargos = co.CargoDetails.ToList();
            return View(cargos);
        }
        [HttpGet]
        public ActionResult CargoAdd()
        {
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