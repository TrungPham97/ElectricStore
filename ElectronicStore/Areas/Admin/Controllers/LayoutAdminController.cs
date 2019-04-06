using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Areas.Admin.Controllers
{
    [ChildActionOnly]
    public class LayoutAdminController : Controller
    {
        // GET: Admin/LayoutAd
        public PartialViewResult Header()
        { 
            return PartialView();
        }
        public PartialViewResult HeaderMobile()
        {
            return PartialView();
        }
        public PartialViewResult MenuSlidebar()
        {
            return PartialView();
        }

    }
}