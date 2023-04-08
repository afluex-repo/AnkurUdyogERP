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
        public string Fk_DistributerId { get; set; }
        public string DistributerName { get; set; }
        public string LoginIDD { get; set; }

        public DataSet GetDistributerListAutoSeach()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@Fk_DistributerId", Fk_DistributerId)};
            DataSet ds = Connection.ExecuteQuery("GetDistributer", para);
            return ds;
        }
    }
}