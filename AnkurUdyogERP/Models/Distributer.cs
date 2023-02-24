using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Distributer : Common
    {
        public List<Distributer> lstDealer { get; set; }
        public string FirmName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; }
        public string GSTNo { get; set; }
        public string Limit { get; set; }
        public string Password { get; set; }
        public string AddedBy { get; set; }
        public string PK_UserId { get; set; }
        public string LoginId { get; set; }
        public string JoiningDate { get; set; }
        public string Name { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public DataSet SaveDealerRegistration()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FirmName",FirmName),
                 new SqlParameter("@FirstName",FirstName),
                  new SqlParameter("@MiddleName",MiddleName),
                   new SqlParameter("@LastName",LastName),
                    new SqlParameter("@Mobile",Mobile),
                     new SqlParameter("@Email",Email),
                      new SqlParameter("@Pincode",Pincode),
                       new SqlParameter("@State",State),
                        new SqlParameter("@City",City),
                         new SqlParameter("@PanNo",PanNo),
                          new SqlParameter("@GSTNo",GSTNo),
                           new SqlParameter("@Limit_MT",Limit),
                            new SqlParameter("@Address",Address),
                             new SqlParameter("@Password",Password),
                              new SqlParameter("@CreatedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveDealerRegistration", para);
            return ds;
        }

        public DataSet GetDealerList()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@PK_UserId",UserID),
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@Name",Name),
                new SqlParameter("@FromDate ", FromDate),
                new SqlParameter("@ToDate ", ToDate),
            };
            DataSet ds = Connection.ExecuteQuery("GetDealerList", para);
            return ds;
        }
    }
}