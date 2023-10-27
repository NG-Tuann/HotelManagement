using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class PhieuDichVu
    {
        public string MaDv { get; set; }
        public string MaCtdp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual ChiTietDatPhong MaCtdpNavigation { get; set; }
        public virtual DichVu MaDvNavigation { get; set; }
    }
}
