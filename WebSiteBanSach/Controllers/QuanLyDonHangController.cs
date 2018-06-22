using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;
using PagedList.Mvc;
using System.IO;
using System.Net.Http;
namespace WebSiteBanSach.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: TacGia
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page, string SearchText)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            int parsedValue;
            if (!string.IsNullOrEmpty(SearchText))
            {
                if (Int32.TryParse(SearchText, out parsedValue))
                {
                    var result = db.DonHangs.AsEnumerable().Where(s => s.MaDonHang.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize = 100));

                }

                else
                {
                    var result = db.DonHangs.Where(s => s.KhachHang.HoTen.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize = 100));
                }

            }

            return View(db.DonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));
            // return View();
        }

        // GET: TacGia/Details/5
        public ActionResult HienThi(int maDonHang)
        {
            DonHang donHang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == maDonHang);
            if (donHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(donHang);
            //return View();
        }

        // GET: TacGia/Create
        public ActionResult ThemMoi()
        {
            return View();
        }

        // POST: TacGia/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(DonHang donHang, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TacGia/Edit/5
        public ActionResult ChinhSua(int maDonHang)
        {
            DonHang donHang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == maDonHang);
            if (donHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donHang);
        }

        // POST: TacGia/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(DonHang donHang, FormCollection f)
        {
            try
            {
                // TODO: Add update logic here
                //Thêm vào cơ sở dữ liệu
                if (ModelState.IsValid)
                {
                    //Thực hiện cập nhận trong model
                    db.Entry(donHang).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TacGia/Delete/5
        public ActionResult Xoa(int maDonHang)
        {
            DonHang donHang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == maDonHang);
            if (donHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(donHang);
            //return View();
        }

        // POST: TacGia/Delete/5
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int maDonHang, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DonHang donHang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == maDonHang);
                if (donHang == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.DonHangs.Remove(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
