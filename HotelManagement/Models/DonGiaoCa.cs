using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class DonGiaoCa
    {
        public string MaDonGiaoCa { get; set; }
        public string MaTkCaTruc { get; set; }
        public string MaTkCaSau { get; set; }
        public decimal? TienGiaoCa { get; set; }
        public decimal? TienChenhLech { get; set; }
        public string GhiChu { get; set; }

        public virtual TaiKhoan MaTkCaSauNavigation { get; set; }
        public virtual TaiKhoan MaTkCaTrucNavigation { get; set; }
    }
}
