using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        Context co = new Context();
        // GET: Statistics
        public ActionResult Index()
        {
            var value1 = co.Currents.Count().ToString();
            ViewBag.d1 = value1;
            var value2 = co.Products.Count().ToString();
            ViewBag.d2 = value2;
            var value3 = co.Personnels.Count().ToString();
            ViewBag.d3 = value3;
            var value4 = co.Categories.Count().ToString();
            ViewBag.d4 = value4;
            var value5 = co.Products.Sum(x => x.ProductStock).ToString();
            ViewBag.d5 = value5;

            var value6 = (from x in co.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.d6 = value6;

            var value7 = co.Products.Count(x => x.ProductStock <= 20).ToString();
            ViewBag.d7 = value7;

            var value8 = (from x in co.Products orderby x.ProductSalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;

            var value9 = (from x in co.Products orderby x.ProductSalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;

            var value10 = co.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = value10;

            var value11 = co.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = value11;

            var value14 = co.SalesTransactions.Sum(x => x.SalesTotalAmount).ToString();
            ViewBag.d14 = value14;

            //Aynı Gün Yapılan Satış Sayısı
            DateTime todayy = DateTime.Today;
            var value15 = co.SalesTransactions.Count(x => x.SalesDateTime == todayy).ToString();
            ViewBag.d15 = value15;

            // Bugünkü satışların toplamı bugünün tarihine eşit olanları getir ve toplam tutarları topla
            if (Convert.ToInt32(value15) != 0)
            {
                var value16 = co.SalesTransactions.Where(x => x.SalesDateTime == todayy).Sum(y => y.SalesTotalAmount).ToString();
                ViewBag.d16 = value16;
            }
            else
            {
                ViewBag.d16 = value15;
            }


            return View();
        }
    }
}