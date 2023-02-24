using AnkurUdyogERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkurUdyogERP.Controllers
{
    public class DistributerController : Controller
    {
        // GET: Distributer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DistributerDashboard()
        {
            return View();
        }
        public ActionResult GetStateCity(string Pincode)
        {
            try
            {
                Common model = new Common();
                model.Pincode = Pincode;

                #region GetStateCity
                DataSet dsStateCity = model.GetStateCity();
                if (dsStateCity != null && dsStateCity.Tables[0].Rows.Count > 0)
                {
                    model.State = dsStateCity.Tables[0].Rows[0]["State"].ToString();
                    model.City = dsStateCity.Tables[0].Rows[0]["City"].ToString();
                    model.Result = "yes";
                }
                else
                {
                    model.State = model.City = "";
                    model.Result = "no";
                }
                #endregion
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult DealerRegistration(Distributer model, string Id)
        {
            if (Id != null)
            {
                model.PK_UserId = Id;
                DataSet ds = model.GetDealerList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    model.MiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                    model.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    model.Pincode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    model.State = ds.Tables[0].Rows[0]["State"].ToString();
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    model.JoiningDate = ds.Tables[0].Rows[0]["JoiningDate"].ToString();
                    model.FirmName = ds.Tables[0].Rows[0]["FirmName"].ToString();
                    model.GSTNo = ds.Tables[0].Rows[0]["GSTNo"].ToString();
                    model.Limit = ds.Tables[0].Rows[0]["Limit_MT"].ToString();
                    model.PanNo = ds.Tables[0].Rows[0]["PancardNo"].ToString();
                }
            }
            return View(model);
        }
        [HttpPost]
        [ActionName("DealerRegistration")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult DealerRegistration(Distributer model)
        {
            try
            {
                model.AddedBy = Session["PK_UserId"].ToString();
                var Pass = Common.GenerateAlphaNumericNumber();
                model.Password = Pass;
                DataSet ds = model.SaveDealerRegistration();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["msg"] = "Dealer Registration Saved Successfully !!";
                    }
                    else
                    {
                        TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("DealerRegistration", "Distributer");
        }
        [HttpPost]
        [ActionName("DealerRegistration")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateDealer(Distributer model, string PK_UserId)
        {
            try
            {
                model.UserID = PK_UserId;
                if (model.UserID != null)
                {
                    model.AddedBy = Session["PK_UserId"].ToString();
                    DataSet ds = model.UpdateDealer();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() == "1")
                        {
                            TempData["msg"] = "Dealer Details Updated  Successfully !!";
                        }
                        else
                        {
                            TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("DealerRegistration", "Distributer");
        }
        public ActionResult DealerList()
        {
            Distributer model = new Distributer();
            List<Distributer> lst = new List<Distributer>();
            //model.AddedBy = Session["PK_UserId"].ToString();
            DataSet ds = model.GetDealerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Distributer obj = new Distributer();
                    obj.PK_UserId = dr["PK_UserId"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Pincode = dr["PinCode"].ToString();
                    obj.State = dr["State"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    obj.FirmName = dr["FirmName"].ToString();
                    obj.GSTNo = dr["GSTNo"].ToString();
                    obj.Limit = dr["Limit_MT"].ToString();
                    obj.PanNo = dr["PancardNo"].ToString();
                    lst.Add(obj);
                }
                model.lstDealer = lst;
            }
            return View(model);
        }
        [HttpPost]
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("DealerList")]
        public ActionResult DealerList(Distributer model)
        {
            List<Distributer> lst = new List<Distributer>();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds = model.GetDealerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Distributer obj = new Distributer();
                    obj.PK_UserId = dr["PK_UserId"].ToString();
                    obj.LoginId = dr["LoginId"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Pincode = dr["PinCode"].ToString();
                    obj.State = dr["State"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.JoiningDate = dr["JoiningDate"].ToString();
                    lst.Add(obj);
                }
                model.lstDealer = lst;
            }
            return View(model);
        }

        public ActionResult DeleteDealer(Distributer model, string Id)
        {
            try
            {
                model.AddedBy = Session["PK_UserId"].ToString();
                model.PK_UserId = Id;
                DataSet ds = model.DeleteDealer();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Dealer"] = "Dealer Details Deleted  Successfully !!";
                    }
                    else
                    {
                        TempData["Dealer"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Dealer"] = ex.Message;
            }
            return RedirectToAction("DealerList", "Distributer");
        }
    }
}