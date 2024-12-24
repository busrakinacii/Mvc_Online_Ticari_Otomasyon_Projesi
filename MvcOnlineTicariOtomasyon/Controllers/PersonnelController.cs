using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
            var values = co.Personnels.Where(x => x.PersonnelStatus == true).ToList();
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
            if (Request.Files.Count > 0)
            {
                string FName = Path.GetFileName(Request.Files[0].FileName);
                string FExtension = Path.GetExtension(Request.Files[0].FileName);
                string FPath = "~/Image/" + FName + FExtension;
                Request.Files[0].SaveAs(Server.MapPath(FPath));
                p.PersonnelImage = "/Image/" + FName + FExtension;

            }

            p.PersonnelStatus = true;
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
        public ActionResult PersonnelDelete(int id)
        {
            var del = co.Personnels.Find(id);
            del.PersonnelStatus = false;
            co.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonnelList()
        {
            var query = co.Personnels.ToList();
            return View(query);
        }


    }
}