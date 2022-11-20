using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class HoaDon
    {
        public string Mahd { get; set; }
        public string Httt { get; set; }
        public string MaDonDat { get; set; }
        public decimal? TongTien { get; set; }
        public string MaTaiKhoan { get; set; }
        public decimal? PhuThu { get; set; }
        public string GhiChu { get; set; }
        public string TrangThai { get; set; }

        public virtual DonDatPhong MaDonDatNavigation { get; set; }
        public virtual TaiKhoan MaTaiKhoanNavigation { get; set; }
    }
}
