using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class CtBcDoanhThuNgay
    {
        public DateTime MaBc { get; set; }
        public int? SoLuongHd { get; set; }
        public decimal? TienPhong { get; set; }
        public decimal? TienDichVu { get; set; }
        public decimal? PhuThu { get; set; }
        public decimal? DoanhThu { get; set; }
        public decimal? ThucThuTuHd { get; set; }
        public decimal? TienChi { get; set; }

        public virtual BcDoanhThuNgay MaBcNavigation { get; set; }
    }
}
