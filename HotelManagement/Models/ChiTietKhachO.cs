using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class ChiTietKhachO
    {
        public string MaKhachO { get; set; }
        public string MaDonDat { get; set; }

        public virtual DonDatPhong MaDonDatNavigation { get; set; }
        public virtual KhachHang MaKhachONavigation { get; set; }
    }
}
