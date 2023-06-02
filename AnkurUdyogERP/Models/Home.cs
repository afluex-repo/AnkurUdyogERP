using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Home
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Message { get; set; }
        public string CreatedBy {get;set;}


        public DataSet Login()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId),
                 new SqlParameter("@Password",Password)
            };
            DataSet ds = Connection.ExecuteQuery("Login", para);
            return ds;
        }
        public DataSet LoginDistributer()
        {
            SqlParameter[] para =
                {
                new SqlParameter ("@LoginId",LoginId),
                new SqlParameter("@Password",Password)
            };
            DataSet ds = Connection.ExecuteQuery("LoginAsDistributer", para);
            return ds;
        }


        public DataSet SaveContact()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Name", Name),
                 new SqlParameter("@Email", Email),
                  new SqlParameter("@PhoneNo", PhoneNo),
                   new SqlParameter("@Message", Message)
            };
            DataSet ds = Connection.ExecuteQuery("SaveContact", para);
            return ds;
        }
    }
}