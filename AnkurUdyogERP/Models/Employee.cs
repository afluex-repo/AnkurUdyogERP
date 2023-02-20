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
        public string LoginId { get; set; }
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
        public string Result { get; set; }
        public string Password { get; set; }
        public string JoiningDate { get; set; }
        
        public List<Employee> lstEmployee { get; set; }

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
                         new SqlParameter("@Password",Password),
                          new SqlParameter("@Fk_UserTypeId","2"),
                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveEmployeeRegistration", para);
            return ds;
        }
        

        public DataSet GetEmployeeList()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@Pk_AdminId",AddedBy),
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@Name",Name),
            };
            DataSet ds = Connection.ExecuteQuery("GetEmployeeList",para);
            return ds;
        }
        
        
        public DataSet GetStateCity()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Pincode",PinCode),
            };
            DataSet ds = Connection.ExecuteQuery("GetStateCity",para);
            return ds;
        }

        

    }
}