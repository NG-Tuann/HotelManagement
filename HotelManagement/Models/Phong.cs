using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class Phong
    {
        public Phong()
        {
            ChiTietDatPhongs = new HashSet<ChiTietDatPhong>();
        }

        public string Maphong { get; set; }
        public string TinhTrang { get; set; }
        public string MaLp { get; set; }
        public string MaTang { get; set; }
        public int PhongSo { get; set; }

        public virtual LoaiPhong MaLpNavigation { get; set; }
        public virtual Tang MaTangNavigation { get; set; }
        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
    }
}
