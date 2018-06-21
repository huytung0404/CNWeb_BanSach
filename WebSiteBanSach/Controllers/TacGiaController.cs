using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;

namespace WebSiteBanSach.Controllers
{
    public class TacGiaController : Controller
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
                    var result = db.TacGias.AsEnumerable().Where(s => s.MaTacGia.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize = 100));

                }

                else
                {
                    var result = db.TacGias.Where(s => s.TenTacGia.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize = 100));
                }

            }

            return View(db.TacGias.ToList().OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize));
           // return View();
        }

        // GET: TacGia/Details/5
        public ActionResult HienThi(int maTacGia)
        {
            TacGia tacGia = db.TacGias.SingleOrDefault(n => n.MaTacGia == maTacGia);
            if (tacGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(tacGia);
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
        public ActionResult ThemMoi(TacGia tacGia, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                db.TacGias.Add(tacGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TacGia/Edit/5
        public ActionResult ChinhSua(int maTacGia)
        {
            TacGia tacGia = db.TacGias.SingleOrDefault(n => n.MaTacGia == maTacGia);
            if (tacGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tacGia);
        }

        // POST: TacGia/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(TacGia tacGia, FormCollection f)
        {
            try
            {
                // TODO: Add update logic here
                //Thêm vào cơ sở dữ liệu
                if (ModelState.IsValid)
                {
                    //Thực hiện cập nhận trong model
                    db.Entry(tacGia).State = System.Data.Entity.EntityState.Modified;
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
        public ActionResult Xoa(int maTacGia)
        {
            TacGia tacGia = db.TacGias.SingleOrDefault(n => n.MaTacGia == maTacGia);
            if (tacGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(tacGia);
            //return View();
        }

        // POST: TacGia/Delete/5
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int maTacGia, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                TacGia tacGia = db.TacGias.SingleOrDefault(n => n.MaTacGia == maTacGia);
                if (tacGia == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.TacGias.Remove(tacGia);
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
