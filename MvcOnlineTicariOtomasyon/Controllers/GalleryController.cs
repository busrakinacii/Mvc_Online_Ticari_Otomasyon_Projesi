using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context co = new Context();
        public ActionResult Index()
        {
            var value = co.Products.ToList();
            return View(value);
        }
    }
}