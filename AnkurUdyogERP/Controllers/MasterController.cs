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

        public ActionResult DistributerRegistration()
        {
            return View();
        }

        [HttpPost]
        [OnAction(ButtonName = "btnSave")]
        [ActionName("DistributerRegistration")]
        public ActionResult DistributerRegistration(Master model)
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
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
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
        public ActionResult DistributerList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetDistributerList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.DistributerId = dr["DistributerId"].ToString();
                    lst.Add(obj);
                }
                model.lstDistributer = lst;
            }
            return View(model);
        }

    
}
}