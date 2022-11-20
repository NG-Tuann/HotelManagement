using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class BcDoanhThuNgay
    {
        public DateTime Mabc { get; set; }
        public string MaTk { get; set; }
        public decimal? TongDoanhThu { get; set; }
        public decimal? TongThucThu { get; set; }
        public decimal? ChenhLech { get; set; }

        public virtual TaiKhoan MaTkNavigation { get; set; }
        public virtual CtBcDoanhThuNgay CtBcDoanhThuNgay { get; set; }
    }
}
