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

        public ActionResult DealerRegistration()
        {
            return View();
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

        public ActionResult DealerList()
        {
            Distributer model = new Distributer();
            List<Distributer> lst = new List<Distributer>();
            model.AddedBy = Session["PK_UserId"].ToString();
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
        [HttpPost]
        [OnAction(ButtonName = "btnSearch")]
        [ActionName("DealerList")]
        public ActionResult DealerList(Distributer model)
        {
            List<Distributer> lst = new List<Distributer>();
            model.AddedBy = Session["PK_UserId"].ToString();
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
    }
}