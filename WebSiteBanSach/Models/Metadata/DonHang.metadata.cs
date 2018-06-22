using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteBanSach.Models
{
    [MetadataTypeAttribute(typeof(DonHangMetadata))]
    public partial class DonHang
    {
        internal sealed class DonHangMetadata
        {
            [Display(Name = "Mã Đơn Hàng: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaDonHang { get; set; }
            [Display(Name = "Ngày Giao Hàng : ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public Nullable<System.DateTime> NgayGiao { get; set; }
            [Display(Name = "Ngày Đặt Hàng: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public Nullable<System.DateTime> NgayDat { get; set; }
            [Display(Name = "Đã Thanh Toán: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string DaThanhToan { get; set; }
            [Display(Name = "Tình Trạng Giao Hàng: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public Nullable<int> TinhTrangGiaoHang { get; set; }
            [Display(Name = "Mã Khách Hàng: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public Nullable<int> MaKH { get; set; }

            
        }
    }
}