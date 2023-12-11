using PagedList;
using QLDeTai.Models.EF;
using QLDeTai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDeTai.Controllers
{
    public class HocVienController : Controller
    {
        // GET: HocVien
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            IEnumerable<HocVien> items = db.HocViens.OrderByDescending(x => x.Id);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.DonViGV = new SelectList(db.DonViHVs.ToList(), "Id", "TieuDoan");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(HocVien model)
        {
            if (ModelState.IsValid)
            {
                db.HocViens.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonViHV = new SelectList(db.DonViHVs.ToList(), "Id", "TieuDoan");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.DonViHV = new SelectList(db.DonViHVs.ToList(), "Id", "TieuDoan");
            var item = db.GiaoViens.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HocVien model)
        {
            if (ModelState.IsValid)
            {
                db.HocViens.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var item = db.HocViens.Find(id);
            return View(item);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.HocViens.Find(id);
            if (item != null)
            {
                db.HocViens.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

    }
}