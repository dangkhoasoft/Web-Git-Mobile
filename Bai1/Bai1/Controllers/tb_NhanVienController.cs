using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bai1.Models;
using OfficeOpenXml;

namespace Bai1.Controllers
{
    public class tb_NhanVienController : Controller
    {
        private QLNVEntities db = new QLNVEntities();

        // GET: tb_NhanVien
        public ActionResult Index()
        {
            var tb_NhanVien = db.tb_NhanVien.Include(t => t.tb_PhongBan);
            return View(tb_NhanVien.ToList());
        }

        // GET: tb_NhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NhanVien tb_NhanVien = db.tb_NhanVien.Find(id);
            if (tb_NhanVien == null)
            {
                return HttpNotFound();
            }
            return View(tb_NhanVien);
        }

        // GET: tb_NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.MaPB = new SelectList(db.tb_PhongBan, "MaPB", "TenPB");
            return View();
        }

        // POST: tb_NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoTen,CCCD,QueQuan,NgaySinh,SDT,MaPB,Trinhdo")] tb_NhanVien tb_NhanVien)
        {
            if (ModelState.IsValid)
            {
                db.tb_NhanVien.Add(tb_NhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPB = new SelectList(db.tb_PhongBan, "MaPB", "TenPB", tb_NhanVien.MaPB);
            return View(tb_NhanVien);
        }

        // GET: tb_NhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NhanVien tb_NhanVien = db.tb_NhanVien.Find(id);
            if (tb_NhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPB = new SelectList(db.tb_PhongBan, "MaPB", "TenPB", tb_NhanVien.MaPB);
            return View(tb_NhanVien);
        }

        // POST: tb_NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoTen,CCCD,QueQuan,NgaySinh,SDT,MaPB,Trinhdo")] tb_NhanVien tb_NhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_NhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPB = new SelectList(db.tb_PhongBan, "MaPB", "TenPB", tb_NhanVien.MaPB);
            return View(tb_NhanVien);
        }

        // GET: tb_NhanVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NhanVien tb_NhanVien = db.tb_NhanVien.Find(id);
            if (tb_NhanVien == null)
            {
                return HttpNotFound();
            }
            return View(tb_NhanVien);
        }

        // POST: tb_NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_NhanVien tb_NhanVien = db.tb_NhanVien.Find(id);
            db.tb_NhanVien.Remove(tb_NhanVien);
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
       

        public ActionResult ExportToExcel()
        {
            // Lấy dữ liệu từ cơ sở dữ liệu bằng Entity Framework
            var data = db.tb_NhanVien.ToList();

            // Tạo một đối tượng ExcelPackage mới
            using (ExcelPackage package = new ExcelPackage())
            {
                // Tạo một trang tính mới
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Ghi dữ liệu vào tệp Excel
                int row = 1;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.MaNV;
                    worksheet.Cells[row, 2].Value = item.HoTen;
                    worksheet.Cells[row, 3].Value = item.QueQuan;
                    row++;
                }

                // Lưu tệp Excel vào một MemoryStream
                MemoryStream stream = new MemoryStream();
                package.SaveAs(stream);

                // Đặt vị trí luồng về đầu để đảm bảo dữ liệu được ghi đúng
                stream.Position = 0;

                // Trả về tệp Excel dưới dạng FileResult
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Data.xlsx");
            }
        }
    }
}
