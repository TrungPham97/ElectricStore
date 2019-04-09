using System;
using System.Collections.Generic;
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
        public ActionResult OpenModal()
        {
<<<<<<< HEAD
            using (TMDT db = new TMDT())
            {
                List<KhachHang> khlist = db.KhachHangs.Include(a => a.HoaDons).ToList<KhachHang>();
                return Json(new { data = khlist }, JsonRequestBehavior.AllowGet);
            }
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
            return PartialView(khachHang);
        }

<<<<<<< HEAD
        }

        // POST: Admin/KhachHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            if (ModelState.IsValid)
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
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "khachHangID,hoTen,eMail,diaChi,soDienThoai,passWord")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int? id)
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
            return View(khachHang);
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
