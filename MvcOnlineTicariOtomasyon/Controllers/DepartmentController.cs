using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context co = new Context();
        public ActionResult Index()
        {
            var values = co.Departments.Where(x => x.DepartmentStatus == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmentAdd(Department d)
        {
            co.Departments.Add(d);
            co.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDelete(int id)
        {
            var dep = co.Departments.Find(id);
            dep.DepartmentStatus = false;
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentEdit(int id)
        {
            var dpt = co.Departments.Find(id);
            return View("DepartmentEdit", dpt);
        }

        public ActionResult DepartmentUpdate(Department d)
        {
            var dept = co.Departments.Find(d.DepartmentId);
            dept.DepartmentName = d.DepartmentName;
            co.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}