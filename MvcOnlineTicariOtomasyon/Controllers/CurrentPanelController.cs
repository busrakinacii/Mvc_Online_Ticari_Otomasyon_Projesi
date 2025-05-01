using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            var values = co.Messages.Where(x => x.Receiver == mail).ToList();
            ViewBag.m = mail;
            var mailid = co.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentId).FirstOrDefault();
            ViewBag.mid = mailid;
            var totalSales = co.SalesTransactions.Where(x => x.CurrentID == mailid).Count();
            ViewBag.totalSales = totalSales;
            var totalPrice = co.SalesTransactions.Where(x => x.CurrentID == mailid).Sum(y => (decimal?)y.SalesTotalAmount) ?? 0;
            ViewBag.totalPrice = totalPrice;
            var totalProductPrice = co.SalesTransactions.Where(x => x.CurrentID == mailid).Sum(y => (int?)y.SalesPiece) ?? 0;
            ViewBag.totalProductPrice = totalProductPrice;
            var NameSurname = co.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.NameSurname = NameSurname;
            var city = co.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentCity).FirstOrDefault();
            ViewBag.City = city;

            return View(values);
        }
        public ActionResult Orders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = co.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = co.SalesTransactions.Where(x => x.CurrentID == id).ToList();
            return View(values);
        }

        //Gelen Mesajlar
        public ActionResult IncomingMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var message = co.Messages.Where(x => x.Receiver == mail).OrderByDescending(x => x.MessageID).ToList();
            var incomingNumber = co.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incomingNumber;
            var outgoingNumber = co.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outgoingNumber;
            return View(message);
        }

        //Giden Mesajlar
        public ActionResult OutgoingMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var message = co.Messages.Where(x => x.Sender == mail).OrderByDescending(z => z.MessageID).ToList();
            var incomingNumber = co.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incomingNumber;
            var outgoingNumber = co.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outgoingNumber;
            return View(message);
        }
        public ActionResult MessageDetail(int id)
        {
            var value = co.Messages.Where(x => x.MessageID == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var incomingNumber = co.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incomingNumber;
            var outgoingNumber = co.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outgoingNumber;
            return View(value);
        }
        [HttpGet]
        public ActionResult NewMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var incomingNumber = co.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incomingNumber;
            var outgoingNumber = co.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outgoingNumber;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessages(Messages m)
        {
            var mail = (string)Session["CurrentMail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = mail;
            co.Messages.Add(m);
            co.SaveChanges();
            return View();
        }
        public ActionResult CargoTracking(string p)
        {
            var cargos = from x in co.CargoDetails select x;
            cargos = cargos.Where(y => y.TrackingCode.Contains(p));
            return View(cargos.ToList());
        }
        public ActionResult CurrentCargoTracking(string id)
        {
            var value = co.CargoTrackings.Where(x => x.TrackingCode == id).OrderByDescending(y => y.CargoTrackingID).ToList();
            return View(value);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CurrentMail"];
            var id = co.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentId).FirstOrDefault();
            var currentFind = co.Currents.Find(id);
            return PartialView("Partial1", currentFind);
        }
    }
}