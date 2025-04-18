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
    }
}