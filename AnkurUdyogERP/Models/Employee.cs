using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Employee:Common
    {
        public string PK_AdminId { get; set; }
        public string Gender1 { get; set; }
        public string PK_RoleId { get; set; }
        public string RoleName { get; set; }
        public string DistributerId { get; set; }
        


        public List<Employee> lstEmployee { get; set; }

        public DataSet SaveEmployeeRegistration()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Name",Name),
                 new SqlParameter("@FatherName",FatherName),
                  new SqlParameter("@MobileNo",MobileNo),
                   new SqlParameter("@Email",Email),
                    new SqlParameter("@PinCode",Pincode),
                     new SqlParameter("@State",State),
                      new SqlParameter("@City",City),
                       new SqlParameter("@Gender",Gender),
                        new SqlParameter("@Address",Address),
                         new SqlParameter("@Password",Password),
                          new SqlParameter("@Fk_UserTypeId","2"),
                          new SqlParameter("@FK_RoleId",PK_RoleId),
                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveEmployeeRegistration", para);
            return ds;
        }


        public DataSet UpdateEmployee()
        {
            SqlParameter[] para =
            {
               new SqlParameter("@PK_AdminId",PK_AdminId),
                new SqlParameter("@Name",Name),
                 new SqlParameter("@FatherName",FatherName),
                  new SqlParameter("@MobileNo",MobileNo),
                   new SqlParameter("@Email",Email),
                    new SqlParameter("@PinCode",Pincode),
                     new SqlParameter("@State",State),
                      new SqlParameter("@City",City),
                       new SqlParameter("@Gender",Gender),
                        new SqlParameter("@Address",Address),
                           new SqlParameter("@FK_RoleId",PK_RoleId),
                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateEmployee", para);
            return ds;
        }



        public DataSet GetEmployeeList()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@Pk_AdminId",PK_AdminId),
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@Name",Name),
                 new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = Connection.ExecuteQuery("GetEmployeeList",para);
            return ds;
        }


        public DataSet GetProfileDetails()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@Pk_AdminId",PK_AdminId)
            };
            DataSet ds = Connection.ExecuteQuery("GetProfileDetailsForAdmin", para);
            return ds;
        }

        public DataSet GetEmployeeData()
        {
            SqlParameter[] para = { new SqlParameter("@PK_AdminId", PK_AdminId),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@LoginId", LoginId) };

            DataSet ds = Connection.ExecuteQuery("GetEmployeeDetails", para);
            return ds;
        }

        public DataSet DeleteEmployee()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@Pk_AdminId",PK_AdminId),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteEmployee", para);
            return ds;
        }

        public DataSet DeleteDistributer()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@Pk_DistributerId",DistributerId),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteDistributer", para);
            return ds;
        }


        public DataSet GetRoleMasterList()
        {

            SqlParameter[] para =
          {
               new SqlParameter("@PK_RoleId",PK_RoleId)
            };

            DataSet ds = Connection.ExecuteQuery("GetRoleMasterList", para);
            return ds;
        }


    }
}