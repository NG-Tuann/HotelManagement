using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class DonGiaoTien
    {
        public string MaDonGiaoTien { get; set; }
        public string MaTkGiaoTien { get; set; }
        public string MaTkQuanLy { get; set; }
        public decimal? HienCo { get; set; }
        public decimal? TienNhan { get; set; }
        public string GhiChu { get; set; }

        public virtual TaiKhoan MaTkGiaoTienNavigation { get; set; }
        public virtual TaiKhoan MaTkQuanLyNavigation { get; set; }
    }
}
