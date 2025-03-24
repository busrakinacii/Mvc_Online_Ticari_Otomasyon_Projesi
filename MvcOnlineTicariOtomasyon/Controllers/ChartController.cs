using System;
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

    }
}