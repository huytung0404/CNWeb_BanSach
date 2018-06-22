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
    public class QuanLyKhachHangController : Controller
    {
        // GET: KhachHang
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
                    var result = db.KhachHangs.AsEnumerable().Where(s => s.MaKH.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize = 100));

                }

                else
                {
                    var result = db.KhachHangs.Where(s => s.HoTen.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize = 100));
                }

            }

            return View(db.KhachHangs.ToList().OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));
            // return View();
        }

        // GET: KhachHang/Details/5
        public ActionResult HienThi(int maKH)
        {
            KhachHang khachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == maKH);
            if (khachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(khachHang);
            //return View();
        }

        // GET: KhachHang/Create
        public ActionResult ThemMoi()
        {
            return View();
        }

        // POST: TacGia/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(KhachHang khachHang, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TacGia/Edit/5
        public ActionResult ChinhSua(int maKH)
        {
            KhachHang khachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == maKH);
            if (khachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachHang);
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(KhachHang khachHang, FormCollection f)
        {
            try
            {
                // TODO: Add update logic here
                //Thêm vào cơ sở dữ liệu
                if (ModelState.IsValid)
                {
                    //Thực hiện cập nhận trong model
                    db.Entry(khachHang).State = System.Data.Entity.EntityState.Modified;
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
        public ActionResult Xoa(int maKH)
        {
            KhachHang khachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == maKH);
            if (khachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(khachHang);
            //return View();
        }

        // POST: TacGia/Delete/5
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int maKH, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                KhachHang khachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == maKH);
                if (khachHang == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.KhachHangs.Remove(khachHang);
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