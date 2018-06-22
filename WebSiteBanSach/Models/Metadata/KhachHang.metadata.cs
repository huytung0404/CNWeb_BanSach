using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteBanSach.Models
{
    [MetadataTypeAttribute(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã Khách Hàng: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaKH { get; set; }
            [Display(Name = "Tên Khách Hàng: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string HoTen { get; set; }
            [Display(Name = "Ngày Sinh: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<System.DateTime> NgaySinh { get; set; }
            [Display(Name = "Giới Tính: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string GioiTinh { get; set; }
            [Display(Name = "Điện Thoại: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string DienThoai { get; set; }
            [Display(Name = "Tài Khoản: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string TaiKhoan { get; set; }
            [Display(Name = "Mật Khẩu: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string MatKhau { get; set; }
            [Display(Name = "Email: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string Email { get; set; }
            [Display(Name = "Địa Chỉ: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string DiaChi { get; set; }

           
        }
    }
}