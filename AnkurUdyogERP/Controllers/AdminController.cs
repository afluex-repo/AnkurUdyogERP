using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            AdminDashboard model = new AdminDashboard();
            DataSet ds = model.GetDashBoardDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ViewBag.TotalUsers = ds.Tables[0].Rows[0]["TotalUsers"].ToString();
                ViewBag.BlockedUsers = ds.Tables[0].Rows[0]["BlockedUsers"].ToString();
                ViewBag.InactiveUsers = ds.Tables[0].Rows[0]["InactiveUsers"].ToString();
                ViewBag.ActiveUsers = ds.Tables[0].Rows[0]["ActiveUsers"].ToString();
            }
            return View(model);
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
        [OnAction(ButtonName = "Search")]
        [ActionName("EmployeeList")]
        public ActionResult EmployeeList(Employee model)
        {
            List<Employee> lst = new List<Employee>();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
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
        public ActionResult DeleteEmployee(Employee model, string Id)
        {
            try
            {
                model.AddedBy = Session["Pk_adminId"].ToString();
                model.PK_AdminId = Id;
                DataSet ds = model.DeleteEmployee();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["EmployeeRegistration"] = "Employee Deleted  Successfully";
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
            return RedirectToAction("EmployeeList", "Admin");
        }     
        public ActionResult DistributerListForAdmin()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_AdminId = dr["Pk_AdminId"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    obj.MobileNo = dr["Contact"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Pincode = dr["PinCode"].ToString();
                    obj.State = dr["State"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.FirmName = dr["FirmName"].ToString();
                    obj.PanNo = dr["PancardNo"].ToString();
                    obj.GSTNO = dr["GSTNO"].ToString();
                    obj.Limit = dr["Limit"].ToString();
                    lst.Add(obj);
                }
                model.lstDistributer = lst;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult DistributerListForAdmin(Master model)
        {
            List<Master> lst = new List<Master>();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_AdminId = dr["Pk_AdminId"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    obj.MobileNo = dr["Contact"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Pincode = dr["PinCode"].ToString();
                    obj.State = dr["State"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.FirmName = dr["FirmName"].ToString();
                    obj.PanNo = dr["PancardNo"].ToString();
                    obj.GSTNO = dr["GSTNO"].ToString();
                    obj.Limit = dr["Limit"].ToString();
                    lst.Add(obj);
                }
                model.lstDistributer = lst;
            }
            return View(model);
        }
        public ActionResult DeleteDistributer(Employee model, string Id)
        {
            try
            {
                model.AddedBy = Session["Pk_adminId"].ToString();
                model.PK_AdminId = Id;
                DataSet ds = model.DeleteDistributer();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["DeleteDistributer"] = "Distributer Deleted  Successfully";
                    }
                    else
                    {
                        TempData["DeleteDistributer"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["DeleteDistributer"] = ex.Message;
            }
            return RedirectToAction("DistributerListForAdmin", "Admin");
        }
    }
}