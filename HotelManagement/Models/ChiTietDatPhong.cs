using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class ChiTietDatPhong
    {
        public ChiTietDatPhong()
        {
            ChiTietKhachOs = new HashSet<ChiTietKhachO>();
            PhieuDichVus = new HashSet<PhieuDichVu>();
        }

        public string MaDonDatPhong { get; set; }
        public string MaPhong { get; set; }
        public DateTime? NgayThueBd { get; set; }
        public DateTime? NgayThueKt { get; set; }
        public int? GioVao { get; set; }
        public int? GioRa { get; set; }
        public string MaChiTietDatPhong { get; set; }
        public string TrangThai { get; set; }

        public virtual DonDatPhong MaDonDatPhongNavigation { get; set; }
        public virtual Phong MaPhongNavigation { get; set; }
        public virtual ICollection<ChiTietKhachO> ChiTietKhachOs { get; set; }
        public virtual ICollection<PhieuDichVu> PhieuDichVus { get; set; }
    }
}
