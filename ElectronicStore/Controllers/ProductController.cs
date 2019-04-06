using ElectronicStore.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Controllers
{
    public class ProductController : Controller
    {
        TMDT db = new TMDT();
        // GET: Client/Product
        public ActionResult Index()
        {
            var model = db.SanPhams.ToList();
            return PartialView(model);
        }
        public ActionResult Detail(long id)
        {
            var product = db.SanPhams.Find(id);
            return PartialView(product);
        }
        public ActionResult Category()
        {
            var model = db.ThuongHieux.ToList();
            return PartialView(model);
        }
        public ActionResult _Navigation()
        {
            var model = db.DanhMucs.Where(x => x.trangThai == true && x.groupID == 1).ToList();
            return PartialView(model);
        }
    }
}