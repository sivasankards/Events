using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SetAuthentication(string Name, string Email, string Id)
        {
            Session["Name"] = Name;
            Session["Email"] = Email;
            Session["UserId"] = Id;
            FormsAuthentication.SetAuthCookie(Name, true);
            return RedirectToAction("MyEvents", "Event");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}