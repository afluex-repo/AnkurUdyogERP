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
            Distributer newdata = new Distributer();
            try
            {
                newdata.DistributerId = Session["PK_DistributerId"].ToString();
                DataSet Ds = newdata.GetDetails();
                ViewBag.Dealer = Ds.Tables[0].Rows[0]["Dealer"].ToString();
                ViewBag.TodayOrder = Ds.Tables[0].Rows[0]["TodayOrder"].ToString();
                ViewBag.TodayOrderLimit = Ds.Tables[0].Rows[0]["TodayOrderLimit"].ToString();
                ViewBag.TotalOrder = Ds.Tables[0].Rows[0]["TotalOrder"].ToString();
            }
            catch (Exception ex)
            {
                TempData["Dashboard"] = ex.Message;
            }
            return View(newdata);
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
                model.PK_DealerId = Id;
                model.DistributerId = Session["PK_DistributerId"].ToString();
                DataSet ds = model.GetDealerList();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    model.Pincode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    model.State = ds.Tables[0].Rows[0]["State"].ToString();
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    model.JoiningDate = ds.Tables[0].Rows[0]["JoiningDate"].ToString();
                    model.FirmName = ds.Tables[0].Rows[0]["FirmName"].ToString();
                    model.GSTNo = ds.Tables[0].Rows[0]["GSTNo"].ToString();
                    //model.Limit = ds.Tables[0].Rows[0]["Limit_MT"].ToString();
                    model.PanNo = ds.Tables[0].Rows[0]["PancardNo"].ToString();
                }
            }
            List<Distributer> lst = new List<Distributer>();
            model.DistributerId = Session["PK_DistributerId"].ToString();
            DataSet ds1 = model.GetDealerList();
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    Distributer obj = new Distributer();
                    obj.PK_DealerId = dr["PK_DealerId"].ToString();
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
                    //obj.Limit = dr["Limit_MT"].ToString();
                    obj.PanNo = dr["PancardNo"].ToString();
                    lst.Add(obj);
                }
                model.lstDealer = lst;
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
                model.AddedBy = Session["PK_DistributerId"].ToString();
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
        public ActionResult UpdateDealer(Distributer model, string PK_DealerId)
        {
            try
            {
                model.PK_DealerId = PK_DealerId;
                if (model.PK_DealerId != null)
                {
                    model.AddedBy = Session["PK_DistributerId"].ToString();
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
            model.DistributerId = Session["PK_DistributerId"].ToString();
            DataSet ds = model.GetDealerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Distributer obj = new Distributer();
                    obj.PK_DealerId = dr["PK_DealerId"].ToString();
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
                    //obj.Limit = dr["Limit_MT"].ToString();
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
            model.PanNo = model.PanNo == "" ? null : model.PanNo;
            model.DistributerId = Session["PK_DistributerId"].ToString();
            DataSet ds = model.GetDealerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Distributer obj = new Distributer();
                    obj.PK_DealerId = dr["PK_DealerId"].ToString();
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
                    obj.PanNo = dr["PancardNo"].ToString();
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
                model.AddedBy = Session["PK_DistributerId"].ToString();
                model.PK_DealerId = Id;
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



        public ActionResult GetSectionDetails(string Section)
        {
            Distributer model = new Distributer();
            model.Section = Section;
            DataSet ds = model.GetSectionDetails();
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    model.Result = "yes";
                    model.SectionId = ds.Tables[0].Rows[0]["PK_SectionId"].ToString();
                    model.Section = ds.Tables[0].Rows[0]["SectionMaster"].ToString();
                    model.Rate = ds.Tables[0].Rows[0]["Rate"].ToString();
                }
                else
                {
                    model.Result = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                model.Result = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderRequest(Distributer model, string OrderId)
        {
            List<Distributer> lst1 = new List<Distributer>();
            model.DistributerId = Session["PK_DistributerId"].ToString();
            DataSet dss = model.OrderPendingLimit();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dss.Tables[0].Rows)
                {
                    Distributer obj1 = new Distributer();
                    ViewBag.PendingLimit = dr["TodayPendingLimit"].ToString();
                    lst1.Add(obj1);
                }
                model.lstrequest = lst1;
            }

            #region ddldealer
            int dcount = 0;
            Distributer master = new Distributer();
            List<SelectListItem> ddldealer = new List<SelectListItem>();
            master.DistributerId = Session["PK_DistributerId"].ToString();
            DataSet dsdealer = master.GetDealers();
            if (dsdealer != null && dsdealer.Tables.Count > 0 && dsdealer.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dsdealer.Tables[0].Rows)
                {
                    if (dcount == 0)
                    {
                        ddldealer.Add(new SelectListItem { Text = "Select Dealer", Value = "0" });
                    }
                    ddldealer.Add(new SelectListItem { Text = r["Name"].ToString(), Value = r["PK_DealerId"].ToString() });
                    dcount = dcount + 1;
                }
            }
            ViewBag.ddldealer = ddldealer;
            #endregion
            #region ddlSection
            int count = 0;
            Distributer obj = new Distributer();
            List<SelectListItem> ddlsection = new List<SelectListItem>();
            DataSet ds = master.GetSection();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (count == 0)
                    {
                        ddlsection.Add(new SelectListItem { Text = "Select Section", Value = "0" });
                    }
                    ddlsection.Add(new SelectListItem { Text = r["SectionMaster"].ToString(), Value = r["PK_SectionId"].ToString() });
                    count = count + 1;
                }
            }
            ViewBag.ddlsection = ddlsection;
            #endregion

            if (OrderId != null)
            {
                model.OrderId = OrderId;
                DataSet ds1 = model.OrderRequestList();
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    model.OrderId = ds1.Tables[0].Rows[0]["PK_OrderId"].ToString();
                    model.PendingLimit = ds1.Tables[0].Rows[0]["PendingLimit"].ToString();
                    model.Dealer = ds1.Tables[0].Rows[0]["Name"].ToString();
                    model.Section = ds1.Tables[0].Rows[0]["Section"].ToString();
                    model.Rate = ds1.Tables[0].Rows[0]["Rate"].ToString();
                    model.OrderQuantity = ds1.Tables[0].Rows[0]["OrderQuantity"].ToString();
                    model.TotalAmount = ds1.Tables[0].Rows[0]["TotalAmount"].ToString();
                }
            }

            List<Distributer> lst = new List<Distributer>();
            model.DistributerId = Session["PK_DistributerId"].ToString();
            DataSet dslist = model.OrderRequestList();
            if (dslist != null && dslist.Tables.Count > 0 && dslist.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dslist.Tables[0].Rows)
                {
                    Distributer obj1 = new Distributer();
                    obj1.OrderId = dr["PK_OrderId"].ToString();
                    obj1.PendingLimit = dr["PendingLimit"].ToString();
                    obj1.Dealer = dr["Name"].ToString();
                    obj1.Section = dr["Section"].ToString();
                    obj1.Rate = dr["Rate"].ToString();
                    obj1.OrderQuantity = dr["OrderQuantity"].ToString();
                    obj1.TotalAmount = dr["TotalAmount"].ToString();
                    lst.Add(obj1);
                }
                model.lstrequest = lst;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("OrderRequest")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult OrderRequestAction(Distributer model)
        {
            try
            {
                model.AddedBy = Session["PK_DistributerId"].ToString();
                model.Status = "Pending";
                DataSet ds = model.SaveOrderRequest();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["msg"] = "Order Request Saved Successfully !!";
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
            return RedirectToAction("OrderRequest", "Distributer");
        }


        [HttpPost]
        [ActionName("OrderRequest")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateOrderRequest(Distributer model, string OrderId)
        {
            try
            {
                model.OrderId = OrderId;
                if (model.OrderId != null)
                {
                    model.AddedBy = Session["PK_DistributerId"].ToString();
                    DataSet ds = model.UpdateOrderRequest();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() == "1")
                        {
                            TempData["msg"] = "Order Request Updated  Successfully !!";
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
            return RedirectToAction("OrderRequest", "Distributer");
        }

        public ActionResult OrderRequestList()
        {
            Distributer model = new Distributer();
            List<Distributer> lst = new List<Distributer>();
            model.DistributerId = Session["PK_DistributerId"].ToString();
            DataSet ds = model.OrderRequestList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Distributer obj = new Distributer();
                    obj.OrderId = dr["PK_OrderId"].ToString();
                    obj.PendingLimit = dr["PendingLimit"].ToString();
                    obj.Dealer = dr["Name"].ToString();
                    obj.Section = dr["Section"].ToString();
                    obj.Rate = dr["Rate"].ToString();
                    obj.OrderQuantity = dr["OrderQuantity"].ToString();
                    obj.TotalAmount = dr["TotalAmount"].ToString();
                    obj.Date = dr["Date"].ToString();
                    obj.Status = (dr["Status"].ToString());
                    lst.Add(obj);
                }
                model.lstrequest = lst;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("OrderRequestList")]
        [OnAction(ButtonName = "btnSearch")]
        public ActionResult OrderRequestList(Distributer model)
        {
            List<Distributer> lst = new List<Distributer>();
            model.DistributerId = Session["PK_DistributerId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds = model.OrderRequestList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Distributer obj = new Distributer();
                    obj.OrderId = dr["PK_OrderId"].ToString();
                    obj.PendingLimit = dr["PendingLimit"].ToString();
                    obj.Dealer = dr["Name"].ToString();
                    obj.Section = dr["Section"].ToString();
                    obj.Rate = dr["Rate"].ToString();
                    obj.OrderQuantity = dr["OrderQuantity"].ToString();
                    obj.TotalAmount = dr["TotalAmount"].ToString();
                    obj.Date = dr["Date"].ToString();
                    obj.Status = (dr["Status"].ToString());
                    lst.Add(obj);
                }
                model.lstrequest = lst;
            }
            return View(model);
        }

        public ActionResult DeleteOrderRequest(Distributer model, string OrderId)
        {
            try
            {
                model.AddedBy = Session["PK_DistributerId"].ToString();
                model.OrderId = OrderId;
                DataSet ds = model.DeleteOrderRequest();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["msg"] = "Order Request Deleted Successfully !!";
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
            return RedirectToAction("OrderRequestList", "Distributer");
        }

        public ActionResult OrderPendingLimit()
        {
            Distributer model = new Distributer();
            List<Distributer> lst = new List<Distributer>();
            model.AddedBy = Session["PK_DistributerId"].ToString();
            DataSet ds = model.OrderPendingLimit();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Distributer obj = new Distributer();
                    obj.OrderId = dr["PK_AdminId"].ToString();
                    obj.PendingLimit = dr["Limit"].ToString();
                    lst.Add(obj);
                }
                model.lstrequest = lst;
            }
            return View(model);
        }
    }
}