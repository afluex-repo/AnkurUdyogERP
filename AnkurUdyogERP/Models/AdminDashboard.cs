using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class AdminDashboard
    {
        public DataSet GetDashBoardDetails()
        {
            DataSet ds = Connection.ExecuteQuery("GetDashBoardDetails");
            return ds;
        }
    }
}