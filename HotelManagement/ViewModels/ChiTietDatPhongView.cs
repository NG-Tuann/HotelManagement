using System;
namespace HotelManagement.ViewModels
{
    public class ChiTietDatPhongView
    {
        public string MA_DON_DAT { get; set;}
        public string TEN_KH { get; set; }
        public DateTime CHECK_IN { get; set; }
        public DateTime CHECK_OUT { get; set; }
        public int PHONG_SO { get; set; }
        public string LOAI_PHONG { get; set; }
        public string CT_DON_DAT { get; set; }
        public string TRANG_THAI { get; set; }
    }
}
