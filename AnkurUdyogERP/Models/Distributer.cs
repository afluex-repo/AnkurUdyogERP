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
        public List<Distributer> lstrequest { get; set; }
        public string FirmName { get; set; }
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

        public string PendingLimit { get; set; }
        public string Dealer { get; set; }
        public string Section { get; set; }
        public string Rate { get; set; }
        public string OrderQuantity { get; set; }
        public string Quintal { get; set; }
        public string Ton { get; set; }
        public string TotalAmount { get; set; }
        public string FK_SectionId { get; set; }
        public string SectionId { get; set; }
        public string PK_SectionId { get; set; }
        public string OrderId { get; set; }
        public string PK_OrderId { get; set; }
        public string Date { get; set; }




        public DataSet GetDetails()
        {
            DataSet ds = Connection.ExecuteQuery("BindDataForDashboard");
            return ds;
        }

        public DataSet SaveDealerRegistration()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FirmName",FirmName),
                 new SqlParameter("@Name",Name),
                    new SqlParameter("@Mobile",Mobile),
                     new SqlParameter("@Email",Email),
                      new SqlParameter("@Pincode",Pincode),
                       new SqlParameter("@State",State),
                        new SqlParameter("@City",City),
                         new SqlParameter("@PanNo",PanNo),
                          new SqlParameter("@GSTNo",GSTNo),
                           //new SqlParameter("@Limit_MT",Limit),
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
                new SqlParameter("@PK_UserId",PK_UserId),
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@Name",Name),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = Connection.ExecuteQuery("GetDealerList", para);
            return ds;
        }

        public DataSet DeleteDealer()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@PK_UserId",PK_UserId),
                new SqlParameter("@AddedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("DeleteDealer", para);
            return ds;
        }

        public DataSet UpdateDealer()
        {
            SqlParameter[] para =
            {
               new SqlParameter("@PK_UserId",UserID),
                new SqlParameter("@FirmName",FirmName),
                 new SqlParameter("@Name",Name),
                    new SqlParameter("@Mobile",Mobile),
                     new SqlParameter("@Email",Email),
                      new SqlParameter("@Pincode",Pincode),
                       new SqlParameter("@State",State),
                        new SqlParameter("@City",City),
                         new SqlParameter("@PanNo",PanNo),
                          new SqlParameter("@GSTNo",GSTNo),
                           //new SqlParameter("@Limit_MT",Limit),
                            new SqlParameter("@Address",Address),
                              new SqlParameter("@UpdatedBy",AddedBy)
            };
            DataSet ds = Connection.ExecuteQuery("UpdateDealer", para);
            return ds;
        }

        public DataSet GetDealers()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@PK_UserId", UserID)
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

        public DataSet SaveOrderRequest()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@PendingLimit",PendingLimit),
                 new SqlParameter("@FK_Dealer",Dealer),
                    new SqlParameter("@FK_SectionId",Section),
                     new SqlParameter("@Rate",Rate),
                      new SqlParameter("@OrderQuantity",OrderQuantity),
                       new SqlParameter("@TotalAmount",TotalAmount),
                       new SqlParameter("@AddedBy",AddedBy)
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

        public DataSet OrderRequestList()
        {
            SqlParameter[] para =
              {
                new SqlParameter("@PK_OrderId",OrderId),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = Connection.ExecuteQuery("OrderRequestList", para);
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
    }
}