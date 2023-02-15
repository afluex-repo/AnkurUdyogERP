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
        public string PK_AdminId { get; set; }
        public string AddedBy { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }


        public List<Employee> lstDistributer { get; set; }

        public DataSet SaveEmployeeRegistration()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Name",Name),
                 new SqlParameter("@FatherName",FatherName),
                  new SqlParameter("@MobileNo",MobileNo),
                   new SqlParameter("@Email",Email),
                    new SqlParameter("@PinCode",PinCode),
                     new SqlParameter("@State",State),
                      new SqlParameter("@City",City),
                       new SqlParameter("@Gender",Gender),
                        new SqlParameter("@Address",Address),
                         new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveEmployeeRegistration", para);
            return ds;
        }

        public DataSet GetEmployeeList()
        {
            DataSet ds = Connection.ExecuteQuery("GetEmployeeList");
            return ds;
        }

        

    }
}