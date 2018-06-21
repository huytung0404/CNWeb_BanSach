using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteBanSach.Models
{
    [MetadataTypeAttribute(typeof(SachMetadata))]
    public partial class TacGia
    {
        internal sealed class SachMetadata
        {
            [Display(Name = "Mã Tác Giả: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaTacGia { get; set; }
            [Display(Name = "Tên Tác Giả: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string TenTacGia { get; set; }
            [Display(Name = "Địa Chỉ: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string DiaChi { get; set; }
            [Display(Name = "Tiểu Sử: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string TieuSu { get; set; }
            [Display(Name = "Điện Thoại: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string DienThoai { get; set; }
        }
    }
}