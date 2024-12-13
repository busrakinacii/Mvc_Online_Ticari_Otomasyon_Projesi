using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using MvcOnlineTicariOtomasyon.Models.Classes;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        Context co = new Context();
        // GET: ToDoList
        public ActionResult Index()
        {
            var value1 = co.Currents.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = co.Products.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = co.Categories.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = (from x in co.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.v4 = value4;

            var toDoList = co.toDoLists.ToList();
            return View(toDoList);
        }
    }
}