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
    public class HoaDonController : Controller
    {
        private TMDT db = new TMDT();

        // GET: Admin/HoaDon
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.ThanhToan);
            return View(hoaDons.ToList());
        }

        // GET: Admin/HoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.maKhach = new SelectList(db.KhachHangs, "khachHangID", "hoTen");
            ViewBag.hoaDonID = new SelectList(db.ThanhToans, "hoaDonID", "hoaDonID");
            return View();
        }

        // POST: Admin/HoaDon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hoaDonID,maKhach,loaiHoaDon,trangThai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maKhach = new SelectList(db.KhachHangs, "khachHangID", "hoTen", hoaDon.maKhach);
            ViewBag.hoaDonID = new SelectList(db.ThanhToans, "hoaDonID", "hoaDonID", hoaDon.hoaDonID);
            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.maKhach = new SelectList(db.KhachHangs, "khachHangID", "hoTen", hoaDon.maKhach);
            ViewBag.hoaDonID = new SelectList(db.ThanhToans, "hoaDonID", "hoaDonID", hoaDon.hoaDonID);
            return View(hoaDon);
        }

        // POST: Admin/HoaDon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hoaDonID,maKhach,loaiHoaDon,trangThai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maKhach = new SelectList(db.KhachHangs, "khachHangID", "hoTen", hoaDon.maKhach);
            ViewBag.hoaDonID = new SelectList(db.ThanhToans, "hoaDonID", "hoaDonID", hoaDon.hoaDonID);
            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
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
