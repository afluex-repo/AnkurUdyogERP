using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Master
    {
        public string DistributerId { get; set; }
        public string AddedBy { get; set; }
        public List<Master> lstDistributer { get; set; }

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