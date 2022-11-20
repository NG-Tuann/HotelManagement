using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class LoaiPhong
    {
        public LoaiPhong()
        {
            Phongs = new HashSet<Phong>();
        }

        public string Malp { get; set; }
        public string LoaiPhong1 { get; set; }
        public string MaGia { get; set; }
        public string KhongGian { get; set; }
        public int SoGiuong { get; set; }
        public int SoNguoi { get; set; }

        public virtual GiaPhong MaGiaNavigation { get; set; }
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
