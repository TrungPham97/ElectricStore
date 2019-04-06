using ElectronicStore.Areas.Admin.Models;
using ElectronicStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace ElectronicStore.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.User_Session];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { controller = "login", action = "index", Area = "Admin" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}