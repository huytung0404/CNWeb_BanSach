using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Net.Http;
namespace WebSiteBanSach.Controllers
{
    public class QuanLyNhaXuatBanController : Controller
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
                    var result = db.NhaXuatBans.AsEnumerable().Where(s => s.MaNXB.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize = 100));

                }

                else
                {
                    var result = db.NhaXuatBans.Where(s => s.TenNXB.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize = 100));
                }

            }

            return View(db.NhaXuatBans.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize));
            // return View();
        }

        // GET: TacGia/Details/5
        public ActionResult HienThi(int maNXB)
        {
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == maNXB);
            if (nhaXuatBan == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(nhaXuatBan);
            //return View();
        }

        // GET: TacGia/Create
        public ActionResult ThemMoi()
        {
            return View();
        }

        // POST: NhaXuatBan/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(NhaXuatBan nhaXuatBan, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                db.NhaXuatBans.Add(nhaXuatBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TacGia/Edit/5
        public ActionResult ChinhSua(int maNXB)
        {
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == maNXB);
            if (nhaXuatBan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaXuatBan);
        }

        // POST: TacGia/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(NhaXuatBan nhaXuatBan, FormCollection f)
        {
            try
            {
                // TODO: Add update logic here
                //Thêm vào cơ sở dữ liệu
                if (ModelState.IsValid)
                {
                    //Thực hiện cập nhận trong model
                    db.Entry(nhaXuatBan).State = System.Data.Entity.EntityState.Modified;
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
        public ActionResult Xoa(int maNXB)
        {
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == maNXB);
            if (nhaXuatBan == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(nhaXuatBan);
            //return View();
        }

        // POST: TacGia/Delete/5
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int maNXB, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                NhaXuatBan nhaXuatBan = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == maNXB);
                if (nhaXuatBan == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.NhaXuatBans.Remove(nhaXuatBan);
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
