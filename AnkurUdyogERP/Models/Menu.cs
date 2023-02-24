using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AnkurUdyogERP.Models
{
    public class Menu
    {
        public string PK_MenuId { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string Sequence { get; set; }
        public string PK_SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public string FK_MenuId { get; set; }
        public List<Menu> lstMenu { get; set; }
        public List<Menu> lstSubMenu { get; set; }

        public DataSet GetMenu()
        {
            DataSet ds = Connection.ExecuteQuery("FindMenu");
            return ds;
        }
    }
}