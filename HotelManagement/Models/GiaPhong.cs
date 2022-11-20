using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class GiaPhong
    {
        public GiaPhong()
        {
            LoaiPhongs = new HashSet<LoaiPhong>();
        }

        public string Magia { get; set; }
        public decimal? GiaTheoGio { get; set; }
        public decimal? GiaTheoNgay { get; set; }
        public decimal? GiaTheoTuan { get; set; }
        public decimal? GiaTheoThang { get; set; }
        public DateTime? NgayHieuLucBd { get; set; }
        public DateTime? NgayHieuLucKt { get; set; }
        public string GhiChu { get; set; }
        public decimal? Qua_1h { get; set; }
        public decimal? Qua_2h { get; set; }
        public decimal? Truoc_3h { get; set; }
        public decimal? Truoc_4h { get; set; }

        public virtual ICollection<LoaiPhong> LoaiPhongs { get; set; }
    }
}
