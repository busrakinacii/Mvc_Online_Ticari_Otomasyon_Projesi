using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        Context co = new Context();
        // GET: ToDoList
        public ActionResult Index()
        {
            return View();
        }
    }
}