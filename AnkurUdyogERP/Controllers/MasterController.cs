﻿using AnkurUdyogERP.Models;
using Newtonsoft.Json;
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
                model.DistributerId = Id;
                DataSet ds = model.GetDistributerList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    model.MobileNo = ds.Tables[0].Rows[0]["Mobile"].ToString();
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
        public ActionResult UpdateDistributer(Master model, string DistributerId)
        {
            try
            {
                if (DistributerId != null)
                {
                    model.DistributerId = DistributerId;
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
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.DistributerId = dr["PK_DistributerId"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    obj.MobileNo = dr["Mobile"].ToString();
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
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.DistributerId = dr["PK_DistributerId"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    obj.MobileNo = dr["Mobile"].ToString();
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
            List<Menu> lstmenu = new List<Menu>();
            List<Menu> lstsubmenu = new List<Menu>();
            model.Pk_AdminId = Session["Pk_adminId"].ToString();
            model.UserType = Session["UserType"].ToString();
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
                    lstmenu.Add(obj);
                }
                model.lstMenu = lstmenu;

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    Menu obj = new Menu();
                    obj.PK_SubMenuId = dr["PK_FormId"].ToString();
                    obj.SubMenuName = dr["FormName"].ToString();
                    //obj.Sequence = dr["Sequence"].ToString();
                    obj.Sequence = dr["DisplaySequence"].ToString();

                    //obj.PK_MenuId = dr["PK_FormTypeId"].ToString();
                    obj.PK_MenuId = dr["FK_FormTypeId"].ToString();
                    

                    obj.Url = dr["Url"].ToString();
                    lstsubmenu.Add(obj);
                }
                model.lstSubMenu = lstsubmenu;
            }
            return PartialView("_GetMenu", model);
        }
        public ActionResult RoleMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.PK_RoleId = Id;
                DataSet ds = model.GetRoleMasterList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                }
            }
            return View(model);
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSave")]
        [ActionName("RoleMaster")]
        public ActionResult RoleMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.SaveRoleMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["RoleMaster"] = "Role Name Save Successfully";
                    }
                    else
                    {
                        TempData["RoleMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["RoleMaster"] = ex.Message;
            }
            return RedirectToAction("RoleMaster", "Master");
        }

        [HttpPost]
        [OnAction(ButtonName = "btnUpdate")]
        [ActionName("RoleMaster")]
        public ActionResult UpdateRoleMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.UpdateRoleMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["RoleMaster"] = "Role Name Updated Successfully";
                    }
                    else
                    {
                        TempData["RoleMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["RoleMaster"] = ex.Message;
            }
            return RedirectToAction("RoleMaster", "Master");
        }
        public ActionResult RoleList()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetRoleMasterList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_RoleId = dr["PK_RoleId"].ToString();
                    obj.RoleName = dr["RoleName"].ToString();
                    lst.Add(obj);
                }
                model.lstRole = lst;
            }
            return View(model);
        }
        public ActionResult DeleteRoleMaster(Master model, string Id)
        {
            try
            {
                model.PK_RoleId = Id;
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.DeleteRoleMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["RoleMaster"] = "Role Name Deleted Successfully";
                    }
                    else
                    {
                        TempData["RoleMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["RoleMaster"] = ex.Message;
            }
            return RedirectToAction("RoleList", "Master");
        }
        public ActionResult GetMenuDetails(string URL)
        {
            try
            {
                Master model = new Master();
                model.Fk_UserId = Session["Pk_AdminId"].ToString();
                model.UserType = Session["UserTypeName"].ToString();
                model.Url = URL;
                DataSet ds = model.GetMenuPermissionList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        var MenuList = JsonConvert.SerializeObject(ds.Tables[0]);
                        return Json(MenuList, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("0", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult SectionMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.PK_SectionId = Id;
                DataSet ds1 = model.GetSectionMasterList();
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    model.SectionMaster = ds1.Tables[0].Rows[0]["SectionMaster"].ToString();
                    model.Rate = ds1.Tables[0].Rows[0]["Rate"].ToString();
                }
            }

            List<Master> lst = new List<Master>();
            DataSet ds = model.GetSectionMasterList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_SectionId = dr["PK_SectionId"].ToString();
                    obj.SectionMaster = dr["SectionMaster"].ToString();
                    obj.Rate = dr["Rate"].ToString();
                    lst.Add(obj);
                }
                model.lstsection = lst;
            }
            return View(model);
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSave")]
        [ActionName("SectionMaster")]
        public ActionResult SectionMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.SaveSectionMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["SectionMaster"] = "Record Save Successfully";
                    }
                    else
                    {
                        TempData["SectionMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["SectionMaster"] = ex.Message;
            }
            return RedirectToAction("SectionMaster", "Master");
        }
        [HttpPost]
        [OnAction(ButtonName = "btUpdate")]
        [ActionName("SectionMaster")]
        public ActionResult UpdateSectionMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.UpdateSectionMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["SectionMaster"] = "Record Update Successfully";
                    }
                    else
                    {
                        TempData["SectionMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["SectionMaster"] = ex.Message;
            }
            return RedirectToAction("SectionMaster", "Master");
        }
        public ActionResult DeleteSectionMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.PK_SectionId = Id;
                    model.AddedBy = Session["Pk_AdminId"].ToString();
                    DataSet ds = model.DeleteSectionMaster();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() == "1")
                        {
                            TempData["SectionMasterList"] = "Record Deleted Successfully";
                        }
                        else
                        {
                            TempData["SectionMasterList"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["SectionMasterList"] = ex.Message;
            }
            return RedirectToAction("SectionMaster", "Master");
        }
        public ActionResult SectionMasterList()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetSectionMasterList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_SectionId = dr["PK_SectionId"].ToString();
                    obj.SectionMaster = dr["SectionMaster"].ToString();
                    obj.Rate = dr["Rate"].ToString();
                    lst.Add(obj);
                }
                model.lstsection = lst;
            }
            return View(model);
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("SectionMasterList")]
        public ActionResult SectionMasterList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetSectionMasterList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_SectionId = dr["PK_SectionId"].ToString();
                    obj.SectionMaster = dr["SectionMaster"].ToString();
                    obj.Rate = dr["Rate"].ToString();
                    lst.Add(obj);
                }
                model.lstsection = lst;
            }
            return View(model);
        }
        public ActionResult DailyRateMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds1 = model.GetDailyRateMaster();
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_DistributerId = dr["PK_DistributerId"].ToString();
                    obj.DistributerName = dr["DistributerName"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    obj.PreviousRate = dr["Rate"].ToString();
                    obj.Date = dr["Date"].ToString();
                    obj.CurrentRate = dr["CurrentRate"].ToString();
                    obj.CurrentDate = dr["CurrentDate"].ToString();
                    lst.Add(obj);
                }
                model.lstdistributerforadmin = lst;
            }
            return View(model);
        }
        public ActionResult SaveTodayRate(Master model, string TodayRate, string FK_DistributerId)
        {
            try
            {
                model.FK_DistributerId = FK_DistributerId;
                model.TodayRate = TodayRate;
                model.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = model.UpdateTodayRate();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        model.Result = "yes";
                        //TempData["TodayRate"] = "New Rate Saved Successfully !!";
                    }
                    else
                    {
                        model.Result = "no";
                        model.Result = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                model.Result = ex.Message;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DealerList()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetDealerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_DealerId = dr["PK_DealerId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.FirmName = dr["FirmName"].ToString();
                    obj.MobileNo = dr["Mobile"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.PanNo = dr["PancardNo"].ToString();
                    obj.GSTNO = dr["GSTNo"].ToString();
                    obj.Pincode = dr["PinCode"].ToString();
                    obj.State = dr["State"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    lst.Add(obj);
                }
                model.lstdealer = lst;
            }
            return View(model);
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("DealerList")]
        public ActionResult GetDealerList(Master model)
        {
            List<Master> lst = new List<Master>();
            model.Name = model.Name == "" ? null : model.Name;
            model.PanNo = model.PanNo == "" ? null : model.PanNo;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds = model.GetDealerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_DealerId = dr["PK_DealerId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.FirmName = dr["FirmName"].ToString();
                    obj.MobileNo = dr["Mobile"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.PanNo = dr["PancardNo"].ToString();
                    obj.GSTNO = dr["GSTNo"].ToString();
                    obj.Pincode = dr["PinCode"].ToString();
                    obj.State = dr["State"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    lst.Add(obj);
                }
                model.lstdealer = lst;
            }
            return View(model);
        }

    }
}