using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
namespace WebSiteBanSach.Models.Metadata
{
    [MetadataTypeAttribute(typeof(NhaXuatBanMetadata))]
    public partial class NhaXuatBan
    {
        internal sealed class NhaXuatBanMetadata
        {
            [Display(Name = "Mã Nhà Xuất Bản: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaNXB { get; set; }
            [Display(Name = "Tên Nhà Xuất Bản: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string TenNXB { get; set; }
            [Display(Name = "Địa Chỉ: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string DiaChi { get; set; }
            [Display(Name = "Điện Thoại: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string DienThoai { get; set; }
        }
    }
}
