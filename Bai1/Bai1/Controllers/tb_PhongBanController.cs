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
    public class tb_PhongBanController : Controller
    {
        private QLNVEntities db = new QLNVEntities();

        // GET: tb_PhongBan
        public ActionResult Index()
        {
            return View(db.tb_PhongBan.ToList());
        }

        // GET: tb_PhongBan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhongBan tb_PhongBan = db.tb_PhongBan.Find(id);
            if (tb_PhongBan == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhongBan);
        }

        // GET: tb_PhongBan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_PhongBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPB,TenPB,SDTPB")] tb_PhongBan tb_PhongBan)
        {
            if (ModelState.IsValid)
            {
                db.tb_PhongBan.Add(tb_PhongBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_PhongBan);
        }

        // GET: tb_PhongBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhongBan tb_PhongBan = db.tb_PhongBan.Find(id);
            if (tb_PhongBan == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhongBan);
        }

        // POST: tb_PhongBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPB,TenPB,SDTPB")] tb_PhongBan tb_PhongBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_PhongBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_PhongBan);
        }

        // GET: tb_PhongBan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhongBan tb_PhongBan = db.tb_PhongBan.Find(id);
            if (tb_PhongBan == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhongBan);
        }

        // POST: tb_PhongBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_PhongBan tb_PhongBan = db.tb_PhongBan.Find(id);
            db.tb_PhongBan.Remove(tb_PhongBan);
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
