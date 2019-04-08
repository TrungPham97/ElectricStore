using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectronicStore.Areas.Admin.Models;

namespace ElectronicStore.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        private TMDT db = new TMDT();
        
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult GetKhachHang()
        {
            using (TMDT db=new TMDT())
            {

                List<KhachHang> khlist = db.KhachHangs.Include(a=>a.HoaDons).ToList<KhachHang>();
                return Json(new { data = khlist }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult OpenModal()
        {
            return PartialView();
        }
        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return PartialView(khachHang);
        }

        // GET: Admin/KhachHang/Create
        [HttpGet]
        public ActionResult CreateOrEdit(int id=0)
        {
            if (id == 0) { return View(new KhachHang()); }
            else
            {
                using(TMDT db=new TMDT())
                {
                    return View(db.KhachHangs.Where(x => x.khachHangID == id).FirstOrDefault());
                }
            }

        }

        // POST: Admin/KhachHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(KhachHang kh)
        {
            
            using(TMDT db=new TMDT())
            {
                if (kh.khachHangID == 0)
                {
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Save Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(kh).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);

                }
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using(TMDT db=new TMDT())
            {
                KhachHang kh = db.KhachHangs.Where(x => x.khachHangID == id).FirstOrDefault();
                db.KhachHangs.Remove(kh);
                db.SaveChanges();
                return Json(new { success = true, message = "Delete Successfully" }, JsonRequestBehavior.AllowGet);

            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
