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
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
        private TMDT db = new TMDT();
>>>>>>> master
>>>>>>> master
        
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
            return View();
=======
           
>>>>>>> master
            return View();
        }
        public ActionResult GetKhachHang()
        {
<<<<<<< HEAD
            using (TMDT db = new TMDT())
            {
                List<KhachHang> khlist = db.KhachHangs.Include(a => a.HoaDons).ToList<KhachHang>();
                return Json(new { data = khlist }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult CreateOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new KhachHang());
            }
            else
            {
=======
            using (TMDT db=new TMDT())
            {

                List<KhachHang> khlist = db.KhachHangs.Include(a=>a.HoaDons).ToList<KhachHang>();
                return Json(new { data = khlist }, JsonRequestBehavior.AllowGet);
            }
>>>>>>> master
        }
        public ActionResult GetKhachHang()
        {
            using (TMDT db = new TMDT())
            {
                List<KhachHang> khlist = db.KhachHangs.Include(a => a.HoaDons).ToList<KhachHang>();
                return Json(new { data = khlist }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult CreateOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new KhachHang());
            }
            else
            {
>>>>>>> master
                using(TMDT db=new TMDT())
                {
                    return View(db.KhachHangs.Where(x => x.khachHangID == id).FirstOrDefault());
                }
            }

<<<<<<< HEAD
        }
        [HttpPost]
=======
<<<<<<< HEAD
=======
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

>>>>>>> master
        }
        [HttpPost]
<<<<<<< HEAD
=======
        [ValidateAntiForgeryToken]
>>>>>>> master
>>>>>>> master
        public ActionResult CreateOrEdit(KhachHang kh)
        {
            
            using(TMDT db=new TMDT())
            {
                if (kh.khachHangID == 0)
                {
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Save Successfully" }, JsonRequestBehavior.AllowGet);
<<<<<<< HEAD

                }
                else
                {
                    db.Entry(kh).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
                }
=======
<<<<<<< HEAD

                }
                else
                {
                    db.Entry(kh).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
                }
=======
                }
                else
                {
                    db.Entry(kh).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);

                }
>>>>>>> master
>>>>>>> master
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

<<<<<<< HEAD

=======
<<<<<<< HEAD
=======

>>>>>>> master

>>>>>>> master

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
