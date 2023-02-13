using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }


        [HttpPost]
        public ActionResult LoginAction(Home model)
        {
            try
            {
              
            }
            catch(Exception ex)
            {

            }
            return View();
        }
    }
}