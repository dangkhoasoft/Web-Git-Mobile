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
    public class tb_ChucVuController : Controller
    {
        private QLNVEntities db = new QLNVEntities();

        // GET: tb_ChucVu
        public ActionResult Index()
        {
            return View(db.tb_ChucVu.ToList());
        }

        // GET: tb_ChucVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChucVu tb_ChucVu = db.tb_ChucVu.Find(id);
            if (tb_ChucVu == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChucVu);
        }

        // GET: tb_ChucVu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_ChucVu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCV,TenCV")] tb_ChucVu tb_ChucVu)
        {
            if (ModelState.IsValid)
            {
                db.tb_ChucVu.Add(tb_ChucVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_ChucVu);
        }

        // GET: tb_ChucVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChucVu tb_ChucVu = db.tb_ChucVu.Find(id);
            if (tb_ChucVu == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChucVu);
        }

        // POST: tb_ChucVu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCV,TenCV")] tb_ChucVu tb_ChucVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ChucVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_ChucVu);
        }

        // GET: tb_ChucVu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChucVu tb_ChucVu = db.tb_ChucVu.Find(id);
            if (tb_ChucVu == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChucVu);
        }

        // POST: tb_ChucVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_ChucVu tb_ChucVu = db.tb_ChucVu.Find(id);
            db.tb_ChucVu.Remove(tb_ChucVu);
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
