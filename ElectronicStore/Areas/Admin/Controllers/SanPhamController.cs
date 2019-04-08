using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectronicStore.Areas.Admin.Models;

namespace ElectronicStore.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private TMDT db = new TMDT();

        // GET: Admin/SanPham
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiHang1).Include(s => s.ThuongHieu1);
            return View(sanPhams.ToList());
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.loaiHang = new SelectList(db.LoaiHangs, "loaiHangID", "tenLoai");
            ViewBag.thuongHieu = new SelectList(db.ThuongHieux, "thuongHieuID", "tenThuongHieu");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sanPhamID,loaiHang,thuongHieu,tenSanPham,donGia,moTa,hinhAnh,nhieuHinhAnh,NgayTao,MetaTitle,Hot")] SanPham sanPham)
        {
            sanPham.NgayTao = DateTime.Now;
            if (ModelState.IsValid)
            {
                object[] sqlParams =
                    {
                    new SqlParameter("@loaiHang", sanPham.loaiHang),
                    new SqlParameter("@thuongHieu", sanPham.thuongHieu),
                    new SqlParameter("@tenSanPham", sanPham.tenSanPham),
                    new SqlParameter("@donGia", sanPham.donGia),
                    new SqlParameter("@moTa", sanPham.moTa),
                    new SqlParameter("@hinhAnh", sanPham.hinhAnh),
                    new SqlParameter("@nhieuHinhAnh", sanPham.nhieuHinhAnh),
                    new SqlParameter("@NgayTao", sanPham.NgayTao),
                    new SqlParameter("@MetaTitle", sanPham.MetaTitle),
                    new SqlParameter("@Hot", sanPham.Hot),
                    };
                try
                {
                    var result = db.Database.ExecuteSqlCommand("sp_ThemSanPham @loaiHang,@thuongHieu,@tenSanPham,@donGia,@moTa,@hinhAnh,@nhieuHinhAnh,@NgayTao,@MetaTitle,@Hot", sqlParams);

                    if (result > 0)
                    {
                        //SetAlert("Thêm thành công", "success");
                        return RedirectToAction("Index");
                    }

                }
                catch (SqlException ex)
                {
                   ModelState.AddModelError("", ex.Message);
                }

            }
            ViewBag.loaiHang = new SelectList(db.LoaiHangs, "loaiHangID", "tenLoai", sanPham.loaiHang);
            ViewBag.thuongHieu = new SelectList(db.ThuongHieux, "thuongHieuID", "tenThuongHieu", sanPham.thuongHieu);
            return View(sanPham);
        }
       
        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.loaiHang = new SelectList(db.LoaiHangs, "loaiHangID", "tenLoai", sanPham.loaiHang);
            ViewBag.thuongHieu = new SelectList(db.ThuongHieux, "thuongHieuID", "tenThuongHieu", sanPham.thuongHieu);
            return View(sanPham);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sanPhamID,loaiHang,thuongHieu,tenSanPham,donGia,moTa,hinhAnh,nhieuHinhAnh,NgayTao,MetaTitle,Hot")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.loaiHang = new SelectList(db.LoaiHangs, "loaiHangID", "tenLoai", sanPham.loaiHang);
            ViewBag.thuongHieu = new SelectList(db.ThuongHieux, "thuongHieuID", "tenThuongHieu", sanPham.thuongHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
