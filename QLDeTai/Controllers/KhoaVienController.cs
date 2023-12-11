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
    public class KhoaVienController : Controller
    {
        // GET: KhoaVien

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            IEnumerable<DonViGV> items = db.donViGVs.OrderByDescending(x => x.Id);
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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DonViGV model)
        {
            if (ModelState.IsValid)
            {

                db.donViGVs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {

            var item = db.donViGVs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DonViGV model)
        {
            if (ModelState.IsValid)
            {
                db.donViGVs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.donViGVs.Find(id);
            if (item != null)
            {
                db.donViGVs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}