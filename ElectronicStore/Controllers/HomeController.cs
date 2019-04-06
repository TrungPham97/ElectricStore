using ElectronicStore.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        TMDT db = new TMDT();
        // GET: Client/Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult _Navigation()
        {
            var model = db.DanhMucs.Where(x => x.trangThai == true && x.groupID == 1).ToList();
            return PartialView(model);
        }
        public ActionResult _BannerBottom()
        {
            var model = db.ThuongHieux.ToList();
            return PartialView(model);
        }
    }
}