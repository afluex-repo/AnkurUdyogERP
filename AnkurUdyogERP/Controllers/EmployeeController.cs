using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class EmployeeController : Controller
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
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.SaveEmployeeRegistration();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["EmployeeRegistration"] = "Employee Registration  Successfully";
                    }
                    else
                    {
                        TempData["EmployeeRegistration"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["EmployeeRegistration"] = ex.Message;
            }
            return RedirectToAction("EmployeeRegistration", "Employee");
        }
        
        public ActionResult EmployeeList()
        {
            Employee model = new Employee();
            List<Employee> lst = new List<Employee>();
            DataSet ds = model.GetEmployeeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Employee obj = new Employee();
                    obj.PK_AdminId = dr["PK_AdminId"].ToString();
                    lst.Add(obj);
                }
                model.lstDistributer = lst;
            }
            return View(model);
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("EmployeeList")]
        public ActionResult EmployeeList(Employee model)
        {
            List<Employee> lst = new List<Employee>();
            DataSet ds = model.GetEmployeeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Employee obj = new Employee();
                    obj.PK_AdminId = dr["PK_AdminId"].ToString();
                    lst.Add(obj);
                }
                model.lstDistributer = lst;
            }
            return View(model);
        }

    }
}