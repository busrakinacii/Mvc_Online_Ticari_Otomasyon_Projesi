using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context co = new Context();
        [Authorize]

        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var values = co.Currents.FirstOrDefault(x => x.CurrentMail == mail);
            ViewBag.m = mail;
            return View(values);
        }
        public ActionResult Orders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = co.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = co.SalesTransactions.Where(x => x.CurrentID == id).ToList();
            return View();
        }
        public ActionResult IncomingMessages()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult NewMessages()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult NewMessages()
        //{
        //    return View();
        //}
    }
}