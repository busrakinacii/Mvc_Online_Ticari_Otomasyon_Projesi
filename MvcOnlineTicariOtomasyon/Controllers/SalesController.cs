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
            var values = co.SalesTransactions.Where(x => x.SalesStatus == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SalesAdd()
        {
            List<SelectListItem> value1 = (from x in co.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in co.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in co.Personnels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonnelName + " " + x.PersonnelSurname,
                                               Value = x.PersonnelId.ToString()
                                           }).ToList();

            ViewBag.val3 = value3;

            ViewBag.val2 = value2;

            ViewBag.val1 = value1;

            return View();
        }
        [HttpPost]
        public ActionResult SalesAdd(SalesTransaction s)
        {
            s.SalesStatus = true;
            s.SalesDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            co.SalesTransactions.Add(s);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesEdit(int id)
        {
            List<SelectListItem> Value1 = (from x in co.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> Value2 = (from x in co.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> Value3 = (from x in co.Personnels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonnelName + " " + x.PersonnelSurname,
                                               Value = x.PersonnelId.ToString()
                                           }).ToList();
            ViewBag.Val1 = Value1;
            ViewBag.Val2 = Value2;
            ViewBag.Val3 = Value3;

            var val = co.SalesTransactions.Find(id);
            return View("SalesEdit", val);
        }

        public ActionResult SalesUpdate(SalesTransaction s)
        {
            var value = co.SalesTransactions.Find(s.SalesTransactionId);
            value.CurrentID = s.CurrentID;
            value.SalesPiece = s.SalesPiece;
            value.SalesPrice = s.SalesPrice;
            value.PersonnelID = s.PersonnelID;
            value.SalesDateTime = s.SalesDateTime;
            value.SalesTotalAmount = s.SalesTotalAmount;
            value.ProductID = s.ProductID;
            co.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SalesDetail(int id)
        {
            var values = co.SalesTransactions.Where(x => x.SalesTransactionId == id).ToList();
            return View(values);
        }
        public ActionResult SalesDelete(int id)
        {
            var sd = co.SalesTransactions.Find(id);
            sd.SalesStatus = false;
            co.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}