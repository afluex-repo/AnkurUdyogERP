using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class AdminDashboard
    {
        public List<AdminDashboard> lstdistributerforadmin { get; set; }
        public List<AdminDashboard> lstgeneralReport { get; set; }
        public string PK_DealerId { get; set; }
        public string DistributerName { get; set; }
        public string JoiningDate { get; set; }
        public string Limit { get; set; }
        public string TodayOrder { get; set; }
        public string DispatchOrder { get; set; }
        public string PendingLimit { get; set; }
        public string TotalDispatch { get; set; }
        public string AddOnLimit { get; set; }
        public string PK_DistributerId { get; set; }
        public string City { get; set; }

        public string CurrentMonthOrder { get; set; }
        public string CurrentMonthDispatch { get; set; }
        public string CurrentMonthPendency { get; set; }




        public DataSet GetDashBoardDetails()
        {
            DataSet ds = Connection.ExecuteQuery("GetDashBoardDetails");
            return ds;
        }
        public DataSet DistributerListForAdminDashboard()
        {
            DataSet ds = Connection.ExecuteQuery("DistributerListForAdminDashboard");
            return ds;
        }

    }
}