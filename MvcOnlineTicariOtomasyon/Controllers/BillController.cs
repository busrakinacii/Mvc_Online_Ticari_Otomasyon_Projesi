﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context co = new Context();
        public ActionResult Index()
        {
            var list = co.Bills.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult BillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BillAdd(Bill b)
        {
            co.Bills.Add(b);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BillEdit(int id)
        {
            var bill = co.Bills.Find(id);
            return View("BillEdit", bill);
        }
        public ActionResult BillUpdate(Bill b)
        {
            var bil = co.Bills.Find(b.BillId);
            bil.BillSerialNumber = b.BillSerialNumber;
            bil.BillOrderNumber = b.BillOrderNumber;
            bil.BillClock = b.BillClock;
            bil.BillDatetime = b.BillDatetime;
            bil.BillTaxOffice = b.BillTaxOffice;
            bil.BillDeliverer = b.BillDeliverer;
            bil.BillRecipient = b.BillRecipient;
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}