using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AnkurUdyogERP.Models
{
    public class Password
    {
        public string Pk_AdminId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string UpdatedBy { get; set; }
        public string ConfirmPass { get; set; }
        public string PasswordType { get; set; }

        public DataSet UpdatePassword()
        {
            SqlParameter[] para = {  new SqlParameter("@OldPassword", OldPassword) ,
                                      new SqlParameter("@NewPassword", NewPassword) ,
                                      new SqlParameter("@UpdatedBy", UpdatedBy) 
                                  };
            DataSet ds = Connection.ExecuteQuery("ChangePassword", para);
            return ds;
        }

        public DataSet ChangePasswordForDistributer()
        {
            SqlParameter[] para = {  new SqlParameter("@OldPassword", OldPassword) ,
                                      new SqlParameter("@NewPassword", NewPassword) ,
                                      new SqlParameter("@UpdatedBy", UpdatedBy)
                                  };
            DataSet ds = Connection.ExecuteQuery("[ChangePasswordForDistributer]", para);
            return ds;
        }
    }
}