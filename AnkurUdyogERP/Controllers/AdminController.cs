using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class AdminController : AdminBaseController
    {
        // GET: Admin
        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult DistributerRegistration()
        {
            return View();
        }

        public ActionResult DistributerList()
        {
            return View();
        }

        [HttpPost]
        [OnAction(ButtonName = "btnSave")]
        [ActionName("DistributerList")]
        public ActionResult DistributerList(Admin model)
        {
            return View();
        }

    }
}