using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Menu
    {
        public string LoginId { get; set; }
        public string PK_MenuId { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string Sequence { get; set; }
        public string PK_SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public string FK_MenuId { get; set; }
        public List<Menu> lstMenu { get; set; }
        public List<Menu> lstSubMenu { get; set; }

        public string Pk_AdminId { get; set; }
        public string UserType { get; set; }

        //public DataSet GetMenu()
        //{
        //    SqlParameter[] para = 
        //        { new SqlParameter("@LoginId", LoginId)
        //    };
        //    DataSet ds = Connection.ExecuteQuery("FindMenu", para);
        //    return ds;
        //}
        
        public DataSet GetMenu()
        {
            SqlParameter[] para = {
                                new SqlParameter("@PK_AdminId", Pk_AdminId),
                                 new SqlParameter("@UserType", UserType)
            };

            DataSet ds = Connection.ExecuteQuery("GetMenuUserWise", para);
            return ds;
        }




    }
}