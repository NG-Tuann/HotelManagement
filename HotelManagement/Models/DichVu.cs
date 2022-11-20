using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class DichVu
    {
        public DichVu()
        {
            PhieuDichVus = new HashSet<PhieuDichVu>();
        }

        public string Madv { get; set; }
        public string TenDv { get; set; }
        public decimal? DonGia { get; set; }
        public string TinhTheo { get; set; }
        public string TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual ICollection<PhieuDichVu> PhieuDichVus { get; set; }
    }
}
