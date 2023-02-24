using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Master:Common
    {
        public string FirmName { get; set; }
        public string GSTNO { get; set; }
        public string Limit { get; set; }
        public string PK_AdminId { get; set; }

        public List<Master> lstDistributer { get; set; }
        
        public DataSet SaveDistributerRegistration()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Name",Name),
                 new SqlParameter("@FirmName",FirmName),
                  new SqlParameter("@MobileNo",MobileNo),
                   new SqlParameter("@Email",Email),
                    new SqlParameter("@PinCode",Pincode),
                     new SqlParameter("@State",State),
                      new SqlParameter("@City",City),
                        new SqlParameter("@PanNo",PanNo),
                        new SqlParameter("@Address",Address),
                         new SqlParameter("@Password",Password),
                           new SqlParameter("@GSTNO",GSTNO),
                             new SqlParameter("@Limit",Limit),
                          new SqlParameter("@Fk_UserTypeId","3"),
                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveDistributerRegistration", para);
            return ds;
        }


        public DataSet UpdateDistributer()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@PK_AdminId",PK_AdminId),
                new SqlParameter("@Name",Name),
                 new SqlParameter("@FirmName",FirmName),
                  new SqlParameter("@MobileNo",MobileNo),
                   new SqlParameter("@Email",Email),
                    new SqlParameter("@PinCode",Pincode),
                     new SqlParameter("@State",State),
                      new SqlParameter("@City",City),
                        new SqlParameter("@PanNo",PanNo),
                        new SqlParameter("@Address",Address),
                           new SqlParameter("@GSTNO",GSTNO),
                             new SqlParameter("@Limit",Limit),
                           new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateDistributer", para);
            return ds;
        }



        public DataSet GetDistributerList()
        {
            SqlParameter[] para =
            {
               new SqlParameter("@Pk_AdminId",PK_AdminId),
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@Name",Name),
                 new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = Connection.ExecuteQuery("GetDistributerList", para);
            return ds;
        }

       


    }
}