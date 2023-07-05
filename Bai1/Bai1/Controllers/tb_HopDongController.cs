using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bai1.Models;

namespace Bai1.Controllers
{
    public class tb_HopDongController : Controller
    {
        private QLNVEntities db = new QLNVEntities();

        // GET: tb_HopDong
        public ActionResult Index()
        {
            var tb_HopDong = db.tb_HopDong.Include(t => t.tb_NhanVien);
            return View(tb_HopDong.ToList());
        }

        // GET: tb_HopDong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_HopDong tb_HopDong = db.tb_HopDong.Find(id);
            if (tb_HopDong == null)
            {
                return HttpNotFound();
            }
            return View(tb_HopDong);
        }

        // GET: tb_HopDong/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.tb_NhanVien, "MaNV", "HoTen");
            return View();
        }

        // POST: tb_HopDong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaNV,LoaiHD,TuNgay,DenNgay")] tb_HopDong tb_HopDong)
        {
            if (ModelState.IsValid)
            {
                db.tb_HopDong.Add(tb_HopDong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.tb_NhanVien, "MaNV", "HoTen", tb_HopDong.MaNV);
            return View(tb_HopDong);
        }

        // GET: tb_HopDong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_HopDong tb_HopDong = db.tb_HopDong.Find(id);
            if (tb_HopDong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.tb_NhanVien, "MaNV", "HoTen", tb_HopDong.MaNV);
            return View(tb_HopDong);
        }

        // POST: tb_HopDong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaNV,LoaiHD,TuNgay,DenNgay")] tb_HopDong tb_HopDong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_HopDong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.tb_NhanVien, "MaNV", "HoTen", tb_HopDong.MaNV);
            return View(tb_HopDong);
        }

        // GET: tb_HopDong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_HopDong tb_HopDong = db.tb_HopDong.Find(id);
            if (tb_HopDong == null)
            {
                return HttpNotFound();
            }
            return View(tb_HopDong);
        }

        // POST: tb_HopDong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_HopDong tb_HopDong = db.tb_HopDong.Find(id);
            db.tb_HopDong.Remove(tb_HopDong);
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
