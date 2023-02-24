using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class MasterController : AdminBaseController
    {
        // GET: Master
        public ActionResult DistributerDashboard()
        {
            return View();
        }
        public ActionResult DistributerRegistration(Master model, string Id)
        {
            if (Id != null)
            {
                model.PK_AdminId = Id;
                DataSet ds = model.GetDistributerList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    model.MobileNo = ds.Tables[0].Rows[0]["Contact"].ToString();
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    model.FirmName = ds.Tables[0].Rows[0]["FirmName"].ToString();
                    model.Pincode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    model.State = ds.Tables[0].Rows[0]["State"].ToString();
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    model.PanNo = ds.Tables[0].Rows[0]["PancardNo"].ToString();
                    model.GSTNO = ds.Tables[0].Rows[0]["GSTNO"].ToString();
                    model.Limit = ds.Tables[0].Rows[0]["Limit"].ToString();
                }
            }
            return View(model);
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSave")]
        [ActionName("DistributerRegistration")]
        public ActionResult DistributerRegistration(Master model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                var Pass = Common.GenerateAlphaNumericNumber();
                model.Password = Pass;
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
            return RedirectToAction("DistributerRegistration", "Master");
        }
        [HttpPost]
        [OnAction(ButtonName = "btnUpdate")]
        [ActionName("DistributerRegistration")]
        public ActionResult UpdateDistributer(Master model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.UpdateDistributer();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["DistributerRegistration"] = "Distributer Updated  Successfully";
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
            return RedirectToAction("DistributerRegistration", "Master");
        }
        public ActionResult DistributerList()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            model.PK_AdminId = Session["Pk_AdminId"].ToString();
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
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
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("DistributerList")]
        public ActionResult DistributerList(Master model)
        {
            List<Master> lst = new List<Master>();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            model.PK_AdminId = Session["Pk_AdminId"].ToString();
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
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



        public ActionResult GetMenu()
        {
            Menu model = new Menu();
            List<Menu> lst = new List<Menu>();
            List<Menu> lstsubmenu = new List<Menu>();
            DataSet ds = model.GetMenu();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Menu obj = new Menu();
                    obj.PK_MenuId = r["PK_FormTypeId"].ToString();
                    obj.MenuName = r["FormType"].ToString();
                    obj.Sequence = r["Sequence"].ToString();
                    obj.Url = r["Url"].ToString();
                    lst.Add(obj);
                }
                model.lstMenu = lst;

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    Menu obj1 = new Menu();
                    obj1.PK_SubMenuId = dr["PK_FormId"].ToString();
                    obj1.SubMenuName = dr["FormName"].ToString();
                    obj1.Sequence = dr["Sequence"].ToString();
                    obj1.PK_MenuId = dr["PK_FormTypeId"].ToString();
                    obj1.Url = dr["Url"].ToString();
                    lstsubmenu.Add(obj1);
                }
                model.lstSubMenu = lstsubmenu;
            }
            return PartialView("_GetMenu", model);
        }
    }
}