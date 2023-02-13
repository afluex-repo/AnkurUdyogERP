using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Employee
    {

        public string DistributerId { get; set; }
        public string AddedBy { get; set; }
        public List<Employee> lstDistributer { get; set; }
        
        public DataSet SaveEmployeeRegistration()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@DistributerId",DistributerId)
            };
            DataSet ds = Connection.ExecuteQuery("SaveDistributerRegistration", para);
            return ds;
        }

        public DataSet GetEmployeeList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@DistributerId",DistributerId)
            };
            DataSet ds = Connection.ExecuteQuery("GetEmployeeList", para);
            return ds;
        }


    }
}