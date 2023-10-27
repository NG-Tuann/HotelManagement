using System;
namespace HotelManagement.ViewModels
{
    public class LoaiPhongView
    {
        public string MALP { get; set; }
        public string LOAI_PHONG { get; set; }
        public string MA_GIA { get; set; }
        public string KHONG_GIAN { get; set; }
        public int SO_GIUONG { get; set; }
        public int SO_NGUOI { get; set; }
        public decimal GIA_THEO_GIO { get; set; }
        public decimal GIA_THEO_NGAY { get; set; }
        public decimal GIA_THEO_TUAN { get; set; }
        public decimal GIA_THEO_THANG { get; set; }
        public DateTime NGAY_BD { get; set; }
        public DateTime NGAY_KT { get; set; }
        public decimal QUA1H { get; set; }
        public decimal QUA2H { get; set; }
        public decimal TRUOC3H { get; set; }
        public decimal TRUOC4H { get; set; }
    }
}
