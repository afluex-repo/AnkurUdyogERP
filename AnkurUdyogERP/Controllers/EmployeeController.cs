using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class EmployeeController : AdminBaseController
    {
        // GET: Employee
        
        public ActionResult EmployeeRegistration()
        {
            return View();
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSave")]
        [ActionName("EmployeeRegistration")]
        public ActionResult EmployeeRegistration(Employee model)
        {
            return View();
        }

        public ActionResult EmployeeList()
        {
            return View();
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("EmployeeList")]
        public ActionResult EmployeeList(Employee model)
        {
            return View();
        }

    }
}