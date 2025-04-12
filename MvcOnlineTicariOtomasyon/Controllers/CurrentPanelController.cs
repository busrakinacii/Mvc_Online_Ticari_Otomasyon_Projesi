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

        //Gelen Mesajlar
        public ActionResult IncomingMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var message = co.Messages.Where(x => x.Receiver == mail).ToList();
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
            var message = co.Messages.Where(x => x.Sender == mail).ToList();
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
            return View();
        }
        [HttpPost]
        public ActionResult NewMessages(Messages m)
        {
            return View();
        }
    }
}