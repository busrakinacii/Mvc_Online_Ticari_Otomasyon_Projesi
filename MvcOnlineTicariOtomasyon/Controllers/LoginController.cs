using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    //global.asax kısmında hepsine authorixe uyguladık ancak AllowAnonymous demek bu controller hariç hepsine uygular
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context co = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Current crnt)
        {
            co.Currents.Add(crnt);
            co.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin1(Current crnt)
        {
            var information = co.Currents.FirstOrDefault(x => x.CurrentMail == crnt.CurrentMail && x.CurrentPassword == crnt.CurrentPassword);
            if (information != null)
            {
                FormsAuthentication.SetAuthCookie(information.CurrentMail, false);
                Session["CurrentMail"] = information.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var values = co.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.AdminUserName, false);
                Session["AdminUserName"] = values.AdminUserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}