using PagedList;
using QLDeTai.Models;
using QLDeTai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace QLDeTai.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien
        private ApplicationDbContext db= new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            IEnumerable<GiaoVien> items = db.GiaoViens.OrderByDescending(x => x.Id);
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
            ViewBag.DonViGV = new SelectList(db.donViGVs.ToList(), "Id", "KhoaVien");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(GiaoVien model)
        {
            if (ModelState.IsValid)
            {
                
                db.GiaoViens.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.DonViGV = new SelectList(db.donViGVs.ToList(), "Id", "KhoaVien");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.DonViGV = new SelectList(db.donViGVs.ToList(), "Id", "KhoaVien");
            var item = db.GiaoViens.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GiaoVien model)
        {
            if (ModelState.IsValid)
            {
                db.GiaoViens.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Detail( int id)
        {
            var item = db.GiaoViens.Find(id);       
                return View(item);
            

         
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.GiaoViens.Find(id);
            if (item != null)
            {
                db.GiaoViens.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }


    }
}