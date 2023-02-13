using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class AdminController : Controller
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

        [HttpPost]
        [OnAction(ButtonName = "btnSave")]
        [ActionName("DistributerRegistration")]
        public ActionResult DistributerRegistration(Admin model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.SaveDistributerRegistration();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["DistributerRegistration"] = "Distributer Registration  Successfully";
                    }
                    else
                    {
                        TempData["DistributerRegistration"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["DistributerRegistration"] = ex.Message;
            }
            return RedirectToAction("DistributerRegistration", "Admin");
        }

        public ActionResult DistributerList()
        {
            Admin model = new Admin();
            List<Admin> lst = new List<Admin>();
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Admin obj = new Admin();
                    obj.DistributerId = dr["DistributerId"].ToString();
                    lst.Add(obj);
                }
                model.lstDistributer = lst;
            }
            return View(model);
        }

        [HttpPost]
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("DistributerList")]
        public ActionResult DistributerList(Admin model)
        {
            List<Admin> lst = new List<Admin>();
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Admin obj = new Admin();
                    obj.DistributerId = dr["DistributerId"].ToString();
                    lst.Add(obj);
                }
                model.lstDistributer = lst;
            }
            return View(model);
        }

    }
}