using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManagementSystem.Models;
using System.Data;
using System.Net.Http;

namespace EventManagementSystem.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyEvents()
        {
            return View();
        }

        public ActionResult Create()
        {
            //if(model != null && this.ModelState.IsValid)
            //{

            //}
            return View();
        }
    }
}