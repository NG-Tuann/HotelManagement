using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class PhieuDichVu
    {
        public string MaDv { get; set; }
        public string MaDonDat { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual DonDatPhong MaDonDatNavigation { get; set; }
        public virtual DichVu MaDvNavigation { get; set; }
    }
}
