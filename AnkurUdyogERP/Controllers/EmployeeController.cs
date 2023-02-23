using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class EmployeeController : AdminBaseController
    {
        // GET: Employee
        
        public ActionResult EmployeeDashboard()
        {
            return View();
        }
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
                model.AddedBy = Session["Pk_adminId"].ToString();
                var Pass = Common.GenerateAlphaNumericNumber();
                model.Password = Pass;
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
        
        public ActionResult GetStateCity(string PinCode)
        {
           Employee model = new Employee();
            model.PinCode = PinCode;
            DataSet ds = model.GetStateCity();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                model.Result = "True";
                model.State = ds.Tables[0].Rows[0]["State"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
            }
            else
            {
            }
            return Json(model,JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult EmployeeList()
        {
            Employee model = new Employee();
            List<Employee> lst = new List<Employee>();
            model.AddedBy = Session["Pk_adminId"].ToString();
            DataSet ds = model.GetEmployeeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Employee obj = new Employee();
                    obj.PK_AdminId = dr["Pk_AdminId"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    obj.MobileNo = dr["Contact"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.FatherName = dr["FatherName"].ToString();
                    obj.Gender = dr["Gender"].ToString();
                    obj.PinCode = dr["PinCode"].ToString();
                    obj.State = dr["State"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    lst.Add(obj);
                }
                model.lstEmployee = lst;
            }
            return View(model);
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("EmployeeList")]
        public ActionResult EmployeeList(Employee model)
        {
            List<Employee> lst = new List<Employee>();
            model.AddedBy = Session["Pk_adminId"].ToString();
            DataSet ds = model.GetEmployeeList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Employee obj = new Employee();
                    obj.PK_AdminId = dr["Pk_AdminId"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    obj.MobileNo = dr["Contact"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.FatherName = dr["FatherName"].ToString();
                    obj.Gender = dr["Gender"].ToString();
                    obj.PinCode = dr["PinCode"].ToString();
                    obj.State = dr["State"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    lst.Add(obj);
                }
                model.lstEmployee = lst;
            }
            return View(model);
        }

    }
}