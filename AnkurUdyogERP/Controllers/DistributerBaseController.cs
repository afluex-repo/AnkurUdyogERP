using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnkurUdyogERP.Controllers
{
    public class DistributerBaseController : Controller
    {
        // GET: DistributerBase
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // code involving this.Session // edited to simplify
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            // If the browser session or authentication session has expired...
            if (session.IsNewSession || Session["PK_DistributerId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                     new { action = "LoginDistributer", Controller = "Home" }));
            }
            else
            {
            }
            base.OnActionExecuting(filterContext); // re-added in edit
        }
    }
}