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
        public ActionResult Login(Home model)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                DataSet ds = model.Login();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if(ds.Tables[0].Rows[0]["UserType"].ToString()== "Admin")
                    {
                        FormName = "AdminDashboard";
                        Controller = "Admin";
                    }
                    else
                    {
                        TempData["msg"] = "Incorrect LoginId Or Password";
                        FormName = "Login";
                        Controller = "Home";
                    }
                      
                }
                else
                {
                    TempData["msg"] = "Incorrect LoginId Or Password";
                    FormName = "Login";
                    Controller = "Home";
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
                FormName = "Login";
                Controller = "Home";
            }
            return RedirectToAction(FormName, Controller);
        }
    }
}