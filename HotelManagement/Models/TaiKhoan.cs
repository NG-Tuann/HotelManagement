using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            BcDoanhThuNgays = new HashSet<BcDoanhThuNgay>();
            DonDatPhongs = new HashSet<DonDatPhong>();
            DonGiaoCaMaTkCaSauNavigations = new HashSet<DonGiaoCa>();
            DonGiaoCaMaTkCaTrucNavigations = new HashSet<DonGiaoCa>();
            DonGiaoTienMaTkGiaoTienNavigations = new HashSet<DonGiaoTien>();
            DonGiaoTienMaTkQuanLyNavigations = new HashSet<DonGiaoTien>();
            HoaDons = new HashSet<HoaDon>();
        }

        public string Matk { get; set; }
        public string TenNv { get; set; }
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
        public string ChucVu { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Cmnd { get; set; }
        public int? GioiTinh { get; set; }

        public virtual ICollection<BcDoanhThuNgay> BcDoanhThuNgays { get; set; }
        public virtual ICollection<DonDatPhong> DonDatPhongs { get; set; }
        public virtual ICollection<DonGiaoCa> DonGiaoCaMaTkCaSauNavigations { get; set; }
        public virtual ICollection<DonGiaoCa> DonGiaoCaMaTkCaTrucNavigations { get; set; }
        public virtual ICollection<DonGiaoTien> DonGiaoTienMaTkGiaoTienNavigations { get; set; }
        public virtual ICollection<DonGiaoTien> DonGiaoTienMaTkQuanLyNavigations { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
