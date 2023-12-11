using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLDeTai.Models;
using QLDeTai.Models.EF;
using PagedList;

namespace QLDeTai.Controllers
{
    public class DeTaisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeTais
        public ActionResult Index(int? page, int? pagesize)
        {
            if(page == null )
            {
                page = 1;
            }
            if(pagesize == null )
            {
                pagesize = 10;
            }
            var detai = db.DeTais.ToList();
            return View(detai.ToPagedList((int)page,(int)pagesize ));
        }

        // GET: DeTais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Include(d => d.HocViens).FirstOrDefault(d => d.Id == id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTrangThai = new SelectList(db.TrangThais, "Id", "TenTrangThai", deTai.IdTrangThai);
            return View(deTai);
        }

        // GET: DeTais/Create


        public ActionResult Create()
        {
            ViewBag.IdTrangThai = new SelectList(db.TrangThais, "Id", "TenTrangThai");
            ViewBag.IdDonVi = new SelectList(db.donViGVs, "Id", "KhoaVien");
            return View();
        }

        // POST: DeTais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenDeTai,NoiDung,MucTieu,NgayDK,NamHoc,NgayCapNhap,GhiChu,Diem,KetLuan,KhenThuong,IdTrangThai,IdTieuBan,IdGiaoVien")] DeTai deTai, GiaoVien giaoVien)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin của giáo viên
                var newGiaoVien = new GiaoVien
                {
                    MaCB = giaoVien.MaCB,
                    TenGV = giaoVien.TenGV,
                    SDT = giaoVien.SDT,
                    Email = giaoVien.Email,
                    HocHam = giaoVien.HocHam,
                    ChucVu = giaoVien.ChucVu,
                    CapBac = giaoVien.CapBac,
                    BoMon = giaoVien.BoMon,
                    IdDonVi = giaoVien.IdDonVi
                };

                db.GiaoViens.Add(newGiaoVien);
                db.SaveChanges();

                // Gán IDGiaoVien của DeTai bằng ID của GiaoVien vừa thêm
                deTai.IdGiaoVien = newGiaoVien.Id;

                // Thêm thông tin đề tài
                db.DeTais.Add(deTai);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.IdGiaoVien = new SelectList(db.GiaoViens, "Id", "TenGiaoVien", deTai.IdGiaoVien);
            ViewBag.IdTrangThai = new SelectList(db.TrangThais, "Id", "TenTrangThai", deTai.IdTrangThai);
            return View(deTai);
        }

        // GET: DeTais/Edit/5
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

            ViewBag.IdTrangThai = new SelectList(db.TrangThais, "Id", "TenTrangThai", deTai.IdTrangThai);
            return View(deTai);
        }

        // POST: DeTais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenDeTai,NoiDung,MucTieu,NgayDK,NamHoc,NgayCapNhap,GhiChu,Diem,KetLuan,KhenThuong,IdTrangThai,IdTieuBan")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                // Lấy DeTai hiện tại từ cơ sở dữ liệu
                var existingDeTai = db.DeTais.Find(deTai.Id);

                if (existingDeTai != null)
                {
                    // Cập nhật chỉ các trường cụ thể
                    existingDeTai.TenDeTai = deTai.TenDeTai;
                    existingDeTai.NoiDung = deTai.NoiDung;
                    existingDeTai.MucTieu = deTai.MucTieu;
                    existingDeTai.NgayDK = deTai.NgayDK;
                    existingDeTai.NamHoc = deTai.NamHoc;
                    existingDeTai.NgayCapNhap = deTai.NgayCapNhap;
                    existingDeTai.GhiChu = deTai.GhiChu;

                    // Đặt EntityState thành Modified
                    db.Entry(existingDeTai).State = EntityState.Modified;

                    // Lưu các thay đổi
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(deTai);
        }

       


        public ActionResult CreateHV()
        {
            ViewBag.IdDeTai = new SelectList(db.DeTais, "Id", "TenDeTai");
            ViewBag.IdDonVi = new SelectList(db.DonViHVs, "id", "TieuDoan");
            return View();
        }

        // POST: HocViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHV([Bind(Include = "Id,MaHV,TruongNhom,TenHV,Khoa,Lop,DaiDoi,GioiTinh,DiemTBC,IdDonVi,IdDeTai")] HocVien hocVien, int? id)
        {
            if (ModelState.IsValid)
            {
                hocVien.IdDeTai = id.Value;
                db.HocViens.Add(hocVien);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = hocVien.IdDeTai });
            }

            ViewBag.IdDeTai = new SelectList(db.DeTais, "Id", "TenDeTai", hocVien.IdDeTai);
            ViewBag.IdDonVi = new SelectList(db.DonViHVs, "id", "TieuDoan", hocVien.IdDonVi);
            return View(hocVien);
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
