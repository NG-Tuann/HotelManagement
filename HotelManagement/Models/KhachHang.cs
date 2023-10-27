using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            ChiTietKhachOs = new HashSet<ChiTietKhachO>();
            DonDatPhongs = new HashSet<DonDatPhong>();
        }

        public string Makh { get; set; }
        public string Cmnd { get; set; }
        public string TenKh { get; set; }
        public string QuocTich { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }

        public virtual ICollection<ChiTietKhachO> ChiTietKhachOs { get; set; }
        public virtual ICollection<DonDatPhong> DonDatPhongs { get; set; }
    }
}
