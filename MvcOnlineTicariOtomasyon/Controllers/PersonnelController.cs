using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        Context co = new Context();
        public ActionResult Index()
        {
            var values = co.Personnels.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult PersonnelAdd()
        {
            List<SelectListItem> listValue = (from x in co.Departments.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmentName,
                                                  Value = x.DepartmentId.ToString()
                                              }).ToList();
            ViewBag.value = listValue;
            return View();
        }
        [HttpPost]
        public ActionResult PersonnelAdd(Personnel p)
        {
            co.Personnels.Add(p);
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonnelEdit(int id)
        {

            List<SelectListItem> listValue = (from x in co.Departments.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmentName,
                                                  Value = x.DepartmentId.ToString()
                                              }).ToList();
            ViewBag.Val = listValue;

            var per = co.Personnels.Find(id);
            return View("PersonnelEdit", per);
        }

        public ActionResult PersonnelUpdate(Personnel per)
        {
            var value = co.Personnels.Find(per.PersonnelId);
            value.PersonnelName = per.PersonnelName;
            value.PersonnelSurname = per.PersonnelSurname;
            value.PersonnelImage = per.PersonnelImage;
            value.DepartmentID = per.DepartmentID;
            co.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}