using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart-Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var chartDraw = new Chart(600, 600);
            chartDraw.AddTitle("Kategori - Ürün Stojk Sayısı").AddLegend("Stok").AddSeries(
                "Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(chartDraw.ToWebImage().GetBytes(), "image/jpeg");

        }
        Context co = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var results = co.Products.ToList();
            results.ToList().ForEach(x => xvalue.Add(x.ProductName));
            results.ToList().ForEach(y => yvalue.Add(y.ProductStock));
            var chart = new Chart(width: 850, height: 850)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(chart.ToWebImage().GetBytes(), "image/jpeg");
        }
    }
}