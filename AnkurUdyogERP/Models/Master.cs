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
        public string RoleName { get; set; }
        public string PK_RoleId { get; set; }
        public List<Master> lstRole { get; set; }
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
                new SqlParameter("@FirmName",FirmName),
                 new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = Connection.ExecuteQuery("GetDistributerList", para);
            return ds;
        }
        

        public DataSet SaveRoleMaster()
        {
            SqlParameter[] para =
            {
               new SqlParameter("@RoleName",RoleName),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveRoleMaster", para);
            return ds;
        }
        public DataSet UpdateRoleMaster()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@PK_RoleId",PK_RoleId),
               new SqlParameter("@RoleName",RoleName),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateRoleMaster", para);
            return ds;
        }
        public DataSet GetRoleMasterList()
        {

            SqlParameter[] para =
          {
               new SqlParameter("@PK_RoleId",PK_RoleId)
            };

            DataSet ds = Connection.ExecuteQuery("GetRoleMasterList",para);
            return ds;
        }
        

        public DataSet DeleteRoleMaster()
        {
            SqlParameter[] para =
            {
               new SqlParameter("@PK_RoleId",PK_RoleId),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteRoleMaster", para);
            return ds;
        }

        





    }
}