using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Master : Common
    {
        public string FirmName { get; set; }
        public string GSTNO { get; set; }
        public string Limit { get; set; }
        public string PK_AdminId { get; set; }
        public string RoleName { get; set; }
        public string PK_RoleId { get; set; }
        public List<Master> lstRole { get; set; }
        public List<Master> lstDistributer { get; set; }
        public List<Master> lstsection { get; set; }
        public string PK_SectionId { get; set; }

        public string Fk_UserId { get; set; }
        public string UserType { get; set; }
        public string Url { get; set; }
        public string SectionMaster { get; set; }
        public string Rate { get; set; }


        public List<Master> lstrequest { get; set; }
        public string DistributerId { get; set; }
        public string UserID { get; set; }
        public string OrderId { get; set; }
        public string PendingLimit { get; set; }
        public string Dealer { get; set; }
        public string Section { get; set; }
        public string OrderQuantity { get; set; }
        public string TotalAmount { get; set; }
        public string Date { get; set; }
        public string Distributer { get; set; }
        public string PK_DistributerId { get; set; }
        public string TodayOrder { get; set; }
        public string AddOnLimit { get; set; }

        public string FK_DistributerId { get; set; }

        public DataTable dtTable { get; set; }

        #region DailyRate
        public string TodayRate { get; set; }
        public string DistributerName { get; set; }
        public string PreviousRate { get; set; }
        public string CurrentRate { get; set; }
        public string CurrentDate { get; set; }
        #endregion

        public List<Master> lstdistributerforadmin { get; set; }
        public List<Master> lstdealer { get; set; }
        public string PK_DealerId { get; set; }

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
            DataSet ds = Connection.ExecuteQuery("DistributerRegistration", para);
            return ds;
        }
        public DataSet UpdateDistributer()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@PK_DistributerId",DistributerId),
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
               new SqlParameter("@PK_DistributerId",DistributerId),
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

            DataSet ds = Connection.ExecuteQuery("GetRoleMasterList", para);
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
        public DataSet GetMenuPermissionList()
        {
            SqlParameter[] para = { new SqlParameter("@PK_AdminId", Fk_UserId),
                                    new SqlParameter("@UserType", UserType),
                                    new SqlParameter("@URL",Url)
            };
            DataSet ds = Connection.ExecuteQuery("GetMenuListForUser", para);
            return ds;
        }
        public DataSet SaveSectionMaster()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@Section", SectionMaster),
                                        new SqlParameter("@Rate", Rate),
                                        new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveSectionMaster", para);
            return ds;
        }
        public DataSet UpdateSectionMaster()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@PK_SectionId", PK_SectionId),
                                        new SqlParameter("@Section", SectionMaster),
                                        new SqlParameter("@Rate", Rate),
                                        new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateSectionMaster", para);
            return ds;
        }
        public DataSet DeleteSectionMaster()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@PK_SectionId", PK_SectionId),
                                        new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteSectionMaster", para);
            return ds;
        }
        public DataSet GetSectionMasterList()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@PK_SectionId",PK_SectionId),
                                        new SqlParameter("@Section", SectionMaster),
                                        new SqlParameter("@Rate", Rate)
            };
            DataSet ds = Connection.ExecuteQuery("GetSectionMasterList", para);
            return ds;
        }
        public DataSet OrderRequestList()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@Fk_DistributerId",DistributerId),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = Connection.ExecuteQuery("OrderRequestListforAdmin", para);
            return ds;
        }
        public DataSet GetDistributer()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_DistributerId",DistributerId)
                                  };
            DataSet ds = Connection.ExecuteQuery("GetDistributer", para);
            return ds;
        }
        //public DataSet RejectOrderRequest()
        //{
        //    SqlParameter[] para =
        //     {
        //        new SqlParameter("@FK_OrderId",OrderId),
        //        new SqlParameter("@Status",Status),
        //        new SqlParameter("@RejectedBy",AddedBy)
        //    };
        //    DataSet ds = Connection.ExecuteQuery("RejectOrderRequest", para);
        //    return ds;
        //}
        //public DataSet ApproveOrderRequest()
        //{
        //    SqlParameter[] para =
        //     {
        //        new SqlParameter("@FK_OrderId",OrderId),
        //        new SqlParameter("@Status",Status),
        //        new SqlParameter("@ApprovedBy",AddedBy)
        //    };
        //    DataSet ds = Connection.ExecuteQuery("ApproveOrderRequest", para);
        //    return ds;
        //}

        public DataSet ApproveOrderRequest()
        {
            SqlParameter[] para =
             {
                 new SqlParameter("@dtPayment",dtTable),
                new SqlParameter("@Status",Status),
                new SqlParameter("@ApprovedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("ApproveOrderRequest", para);
            return ds;
        }

        public DataSet RejectOrderRequest()
        {
            SqlParameter[] para =
             {
                new SqlParameter("@dtPayment",dtTable),
                new SqlParameter("@Status",Status),
                new SqlParameter("@RejectedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("RejectOrderRequest", para);
            return ds;
        }


        public DataSet GetDeoDetails()
        {
            SqlParameter[] para =
             {
                new SqlParameter("@PK_OrderId",OrderId)
            };
            DataSet ds = Connection.ExecuteQuery("GetDeoDetails", para);
            return ds;
        }
        public DataSet SaveIncreaseLimitDateWise()
        {
            SqlParameter[] para =
             {
                new SqlParameter("@Fk_DistributerId",FK_DistributerId),
                //new SqlParameter("@Date",Date),
                new SqlParameter("@AddOnLimit",AddOnLimit),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveIncreaseLimitDateWise", para);
            return ds;


        }
        public DataSet GetDailyRateMaster()
        {
            DataSet ds = Connection.ExecuteQuery("DistributerListForDailyRate");
            return ds;
        }
        public DataSet UpdateTodayRate()
        {
            SqlParameter[] para =
             {
                new SqlParameter("@Fk_DistributerId",FK_DistributerId),
                new SqlParameter("@TodayRate",TodayRate),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveTodayRate", para);
            return ds;


        }
        public DataSet GetDealerList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Name",Name),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                 new SqlParameter("@PancardNo",PanNo)
            };
            DataSet ds = Connection.ExecuteQuery("GetDealerListForAdmin", para);
            return ds;
        }

        #region DispatchReport
        public string DispatchQuantity { get; set; }
        public string DispatchDate { get; set; }
        public string BookingQuantity { get; set; }
        public string Pk_BookingDispatchId { get; set; }
        public string BookingDate { get; set; }
        public List<Master> lstDispatchOrder { get; set; }
        #endregion
        public DataSet GetDispatchReport()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@Fk_DistributerId",DistributerId),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = Connection.ExecuteQuery("GetDispatchReport", para);
            return ds;
        }
    }
}