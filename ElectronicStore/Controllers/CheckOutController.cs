using ElectronicStore.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Controllers
{
    public class CheckOutController : Controller
    {
        TMDT db = new TMDT();
        // GET: CheckOut
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return PartialView("~/Views/Checkout/Payment.cshtml");
        }
        public ActionResult _Navigation()
        {
            var model = db.DanhMucs.Where(x => x.trangThai == true && x.groupID == 1).ToList();
            return PartialView(model);
        }
    }
}