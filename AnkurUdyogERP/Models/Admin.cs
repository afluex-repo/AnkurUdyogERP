using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Admin
    {

        public List<Admin> lstdistributer { get; set; }
        public List<Admin> lstDealer { get; set; }
        public List<Admin> lstrequest { get; set; }
        public List<Admin> lst1DailyRate { get; set; }
        public List<Admin> lstDispatchOrder { get; set; }
        public List<Admin> Delearlist { get; set; }
        public string FirmName { get; set; }
        public string Mobile { get; set; }
        public string UserID { get; set; }
        public string GSTNo { get; set; }
        public string Limit { get; set; }
        public string PK_UserId { get; set; }
        public string PendingLimit { get; set; }
        public string Dealer { get; set; }
        public string Section { get; set; }
        public string Rate { get; set; }
        public string OrderQuantity { get; set; }
        public string Quintal { get; set; }
        public string Ton { get; set; }
        public string TotalAmount { get; set; }
        public string Amount { get; set; }
        public string FK_SectionId { get; set; }
        public string SectionId { get; set; }
        public string PK_SectionId { get; set; }
        public string OrderId { get; set; }
        public string PK_OrderId { get; set; }
        public string Date { get; set; }
        public string DistributerId { get; set; }
        public string PK_DealerId { get; set; }
        public string TodayPendingLimit { get; set; }
        public DataTable dtOrderDetails { get; set; }
        public DataTable dtOrderDispatch { get; set; }
        public string DealerName { get; set; }
        public string DealerId { get; set; }
        public string Dispatched { get; set; }
        public string DispatchPending { get; set; }


        public string Distributor { get; set; }
        public string BookingDate { get; set; }
        public string TotalBookingQuantity { get; set; }
        public string FK_DistributerId { get; set; }

        public string DispatchQuantity { get; set; }
        public string DispatchDate { get; set; }
        public string BookingQuantity { get; set; }
        public string Pk_BookingDispatchId { get; set; }
        public string AddedBy { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }





        public DataSet GetDetails()
        {
            SqlParameter[] para =
                 {
                new SqlParameter("@Pk_DistributerId",DistributerId)
            };
            DataSet ds = Connection.ExecuteQuery("BindDataForDashboard", para);
            return ds;
        }




  

        public DataSet DeleteDealer()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@PK_UserId",PK_DealerId),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteDealer", para);
            return ds;
        }

   

        public DataSet GetDealers()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_DistributerId",DistributerId)
                                  };
            DataSet ds = Connection.ExecuteQuery("GetDealer", para);
            return ds;
        }

        public DataSet GetSection()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@PK_SectionId", FK_SectionId)
                                  };
            DataSet ds = Connection.ExecuteQuery("GetSection", para);
            return ds;
        }

        public DataSet GetSectionDetails()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@PK_SectionId",Section)
            };
            DataSet ds = Connection.ExecuteQuery("GetRate", para);
            return ds;
        }

        //public DataSet SaveOrderRequest()
        //{
        //    SqlParameter[] para =
        //    {
        //        new SqlParameter("@PendingLimit",PendingLimit),
        //         new SqlParameter("@FK_Dealer",Dealer),
        //            new SqlParameter("@FK_SectionId",Section),
        //             new SqlParameter("@Rate",Rate),
        //              new SqlParameter("@OrderQuantity",OrderQuantity),
        //               new SqlParameter("@TotalAmount",TotalAmount),
        //               new SqlParameter("@Status",Status),
        //               new SqlParameter("@AddedBy",AddedBy)
        //    };
        //    DataSet ds = Connection.ExecuteQuery("SaveOrderRequest", para);
        //    return ds;
        //}



        public DataSet SaveOrderRequest()
        {
            SqlParameter[] para = {
                                    new SqlParameter("@AddedBy",AddedBy) ,
                                    new SqlParameter("@Status",Status) ,
                                    new SqlParameter("@dtOrderDetails",dtOrderDetails)

            };
            DataSet ds = Connection.ExecuteQuery("SaveOrderRequest", para);
            return ds;
        }





        public DataSet UpdateOrderRequest()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@PK_OrderId",OrderId),
                new SqlParameter("@PendingLimit",PendingLimit),
                 new SqlParameter("@FK_Dealer",Dealer),
                    new SqlParameter("@FK_SectionId",Section),
                     new SqlParameter("@Rate",Rate),
                      new SqlParameter("@OrderQuantity",OrderQuantity),
                       new SqlParameter("@TotalAmount",TotalAmount),
                       new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateOrderRequest", para);
            return ds;
        }

 

        public DataSet DeleteOrderRequest()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@PK_OrderId",OrderId),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteOrderRequest", para);
            return ds;
        }

        public DataSet OrderPendingLimit()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@PK_DistributerId",DistributerId)
            };
            DataSet ds = Connection.ExecuteQuery("GetLimit", para);
            return ds;
        }

        public DataSet DailyDate()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@FK_DistributerId",DistributerId)
            };
            DataSet ds = Connection.ExecuteQuery("GetDailyRate", para);
            return ds;
        }



        public DataSet GetDealerListAutoSeach()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@FK_DistributerId", DistributerId)};
            DataSet ds = Connection.ExecuteQuery("GetDealerListAutoSeach", para);
            return ds;
        }

        public DataSet DispatchForBookingRequest()
        {
            DataSet ds = Connection.ExecuteQuery("DispatchedForBookingRequest");
            return ds;
        }

        public DataSet DealerDetailsByDistributerId()
        {
            SqlParameter[] para =
              {
                   //new SqlParameter("@OrderDate",BookingDate),
                   //new SqlParameter("@Fk_DistributerId",DistributerId)
            };
            DataSet ds = Connection.ExecuteQuery("DealerDetailsByDistributerId", para);
            return ds;
        }

        public DataSet SaveDispatchForBookingRequest()
        {
            SqlParameter[] para =
            {
                        new SqlParameter("@dtOrderDispatch",dtOrderDispatch),
                        new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("SaveOrderDispatchDetails", para);
            return ds;
        }

    
    }
}