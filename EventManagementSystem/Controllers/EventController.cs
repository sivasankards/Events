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

        [Authorize]
        public ActionResult MyEvents()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
            //return RedirectToAction("MyEvents");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            //string eventId = Request["Event"].ToString();
            ViewBag.EventId = id;
            return View();
        }

        public ActionResult EventHistory()
        {
            return View();
        }
    }
}