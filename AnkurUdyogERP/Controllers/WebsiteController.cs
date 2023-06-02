using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class WebsiteController : Controller
    {
        // GET: Website
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult OurTeam()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult TMXProcess()
        {
            return View();
        }
        public ActionResult Career()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult SaveContact(Home model)
        {
            string formname = "";
            string controller = "";
            try
            {
              
                DataSet ds = model.SaveContact();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Msg"] = "Thanks for contacting with us !";
                        formname = "ContactUs";
                        controller = "Website";
                    }
                    else
                    {
                        TempData["Msg"] = "Contact details have not been saved successfully";
                        formname = "ContactUs";
                        controller = "Website";
                    }
                }
                else
                {
                    TempData["Msg"] = "Contact details have not been saved successfully";
                    formname = "ContactUs";
                    controller = "Website";
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = e.Message;
                formname = "ContactUs";
                controller = "Website";
            }
            return RedirectToAction(formname, controller);
        }
    }
}