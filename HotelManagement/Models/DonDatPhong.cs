using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class DonDatPhong
    {
        public DonDatPhong()
        {
            ChiTietDatPhongs = new HashSet<ChiTietDatPhong>();
            HoaDons = new HashSet<HoaDon>();
        }

        public string Madd { get; set; }
        public decimal? TongTien { get; set; }
        public string MaTk { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public DateTime? NgayTao { get; set; }
        public decimal? SoTienCoc { get; set; }
        public string MaKhDat { get; set; }

        public virtual KhachHang MaKhDatNavigation { get; set; }
        public virtual TaiKhoan MaTkNavigation { get; set; }
        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
