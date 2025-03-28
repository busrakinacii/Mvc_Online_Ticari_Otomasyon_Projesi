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

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<ClassChart> ProductList()
        {
            List<ClassChart> clss = new List<ClassChart>();
            clss.Add(new ClassChart()
            {
                productName = "Bilgisayar",
                productStock = 120
            });
            clss.Add(new ClassChart()
            {
                productName = "Beyaz Eşya",
                productStock = 150
            });
            clss.Add(new ClassChart()
            {
                productName = "Mobilya",
                productStock = 70
            });
            clss.Add(new ClassChart()
            {
                productName = "Küçük Ev Aletleri",
                productStock = 180
            });
            clss.Add(new ClassChart()
            {
                productName = "Mobil Cihazlar",
                productStock = 90
            });
            return clss;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(), JsonRequestBehavior.AllowGet);
        }

        public List<ClassChart2> ProductList2()
        {
            List<ClassChart2> clss = new List<ClassChart2>();
            using (var c = new Context())
            {
                clss = c.Products.Select(x => new ClassChart2
                {
                    prdctName = x.ProductName,
                    prdctStock = x.ProductStock,
                }).ToList();
                return clss;
            }
        }
    }
}