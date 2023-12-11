using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using PagedList;
using QLDeTai.Models;
using QLDeTai.Models.EF;

namespace QLDeTai.Controllers
{
    public class QLDeTaisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QLDeTais
        public ActionResult Index(int? page, int? pagesize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pagesize == null)
            {
                pagesize = 10;
            }
            var detai = db.DeTais.ToList();
            return View(detai.ToPagedList((int)page, (int)pagesize));
        }

        // GET: QLDeTais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // GET: QLDeTais/Create
        

        // GET: QLDeTais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
           
            ViewBag.IdGiaoVien = new SelectList(db.GiaoViens, "Id", "MaCB", deTai.IdGiaoVien);
            ViewBag.IdTieuBan = new SelectList(db.TieuBans, "Id", "TenTieuBan", deTai.IdTieuBan);
            ViewBag.IdTrangThai = new SelectList(db.TrangThais, "Id", "TenTrangThai", deTai.IdTrangThai);
            return View(deTai);
        }

        // POST: QLDeTais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenDeTai,NoiDung,MucTieu,NgayDK,NamHoc,NgayCapNhap,GhiChu,Diem,KetLuan,KhenThuong,IdTrangThai,IdTieuBan,IdGiaoVien")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                // Lấy DeTai hiện tại từ cơ sở dữ liệu
                var existingDeTai = db.DeTais.Find(deTai.Id);

                if (existingDeTai != null)
                {
                    // Giữ giá trị hiện tại của IdGiaoVien
                    deTai.IdGiaoVien = existingDeTai.IdGiaoVien;

                    // Cập nhật các trường cụ thể
                    existingDeTai.TenDeTai = deTai.TenDeTai;
                    existingDeTai.NoiDung = deTai.NoiDung;
                    existingDeTai.MucTieu = deTai.MucTieu;
                    existingDeTai.NgayDK = deTai.NgayDK;
                    existingDeTai.NamHoc = deTai.NamHoc;
                    existingDeTai.NgayCapNhap = deTai.NgayCapNhap;
                    existingDeTai.GhiChu = deTai.GhiChu;
                    existingDeTai.Diem = deTai.Diem;
                    existingDeTai.KetLuan = deTai.KetLuan;
                    existingDeTai.KhenThuong = deTai.KhenThuong;
                    existingDeTai.IdTrangThai = deTai.IdTrangThai;
                    existingDeTai.IdTieuBan = deTai.IdTieuBan;

                    // Đặt EntityState thành Modified
                    db.Entry(existingDeTai).State = EntityState.Modified;

                    // Lưu các thay đổi
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            // Nếu không thành công, cần thiết lập ViewBag cho IdGiaoVien và các SelectList khác
            ViewBag.IdGiaoVien = new SelectList(db.GiaoViens, "Id", "MaCB", deTai.IdGiaoVien);
            ViewBag.IdTieuBan = new SelectList(db.TieuBans, "Id", "TenTieuBan", deTai.IdTieuBan);
            ViewBag.IdTrangThai = new SelectList(db.TrangThais, "Id", "TenTrangThai", deTai.IdTrangThai);

            return View(deTai);
        }

        // GET: QLDeTais/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.DeTais.Find(id);
            if(item != null)
            {
                db.DeTais.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
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
