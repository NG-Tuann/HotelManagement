using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class ChiTietKhachO
    {
        public string MaKhachO { get; set; }
        public string MaChiTietDatPhong { get; set; }

        public virtual ChiTietDatPhong MaChiTietDatPhongNavigation { get; set; }
        public virtual KhachHang MaKhachONavigation { get; set; }
    }
}
