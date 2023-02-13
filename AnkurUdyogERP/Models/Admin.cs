using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Admin
    {
        public string DistributerId { get; set; }
        public string AddedBy { get; set; }
        public List<Admin> lstDistributer { get; set; }

        public DataSet GetDistributerList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@DistributerId",DistributerId)
            };
            DataSet ds = Connection.ExecuteQuery("GetDistributerList", para);
            return ds;
        }

        public DataSet SaveDistributerRegistration()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@DistributerId",DistributerId)
            };
            DataSet ds = Connection.ExecuteQuery("SaveDistributerRegistration", para);
            return ds;
        }


        










    }
}