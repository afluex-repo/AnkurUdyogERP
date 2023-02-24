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
        public ActionResult EmployeeRegistration(Employee model, string Id)
        {
            
            if (Id != null)
            {
                model.PK_AdminId = Id;
                DataSet ds = model.GetEmployeeList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    model.MobileNo = ds.Tables[0].Rows[0]["Contact"].ToString();
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    model.FatherName = ds.Tables[0].Rows[0]["FatherName"].ToString();
                    model.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                    model.Pincode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    model.State = ds.Tables[0].Rows[0]["State"].ToString();
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();

                    ViewBag.Gender = new List<SelectListItem> {
                     new SelectListItem { Value="M", Text="Male"},
                     new SelectListItem { Value="F", Text="FeMale"}
                    };
                    model.Gender = "F";  //Set the selected option here
                }
            }
            else
            {
                List<SelectListItem> Gender = Common.BindGender();
                ViewBag.Gender = Gender;
            }
         
            return View(model);
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
        [HttpPost]
        [OnAction(ButtonName = "btnUpdate")]
        [ActionName("EmployeeRegistration")]
        public ActionResult UpdateEmployee(Employee model)
        {
            try
            {
                if (model.PK_AdminId != null)
                {
                    model.AddedBy = Session["Pk_adminId"].ToString();
                    DataSet ds = model.UpdateEmployee();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() == "1")
                        {
                            TempData["EmployeeRegistration"] = "Employee Updated  Successfully";
                        }
                        else
                        {
                            TempData["EmployeeRegistration"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["EmployeeRegistration"] = ex.Message;
            }
            return RedirectToAction("EmployeeRegistration", "Employee");
        }
        public ActionResult EmployeeConfirmationPage()
        {
            return View();
        }
        public ActionResult GetStateCity(string PinCode)
        {
            Common model = new Common();
            model.Pincode = PinCode;
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
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EmployeeList()
        {
            Employee model = new Employee();
            List<Employee> lst = new List<Employee>();
            model.PK_AdminId = Session["Pk_adminId"].ToString();
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
                    obj.Pincode = dr["PinCode"].ToString();
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
            model.PK_AdminId = Session["Pk_adminId"].ToString();
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
                    obj.Pincode = dr["PinCode"].ToString();
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