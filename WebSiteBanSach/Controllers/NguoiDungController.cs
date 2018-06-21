using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSiteBanSach.Models;

namespace WebSiteBanSach.Controllers
{
    public class NguoiDungController : Controller
    {

        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        // GET: /NguoiDung/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null; // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu vào bảng khách hàng
                db.KhachHangs.Add(kh);
                //Lưu vào csdl 
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            KhachHang ad = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau && n.HoTen == "Admin");
            if (sTaiKhoan != null)
            {
                if (ad != null)
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                    Session["UserName"] = ad.TaiKhoan;
                    Session["TaiKhoan"] = ad;
                    return RedirectToAction("Index", "QuanLySanPham");
                }
                //if (kh != null)
                else
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                    Session["UserName"] = kh.TaiKhoan;
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("Index", "Home");
                }

            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        }
	}
}