using System;
namespace HotelManagement.ViewModels
{
    public class CheckOutView
    {
        public String MA_DON_DAT { get; set; }
        public String MA_CTDP { get; set; }
        public int PHONG_SO { get; set; }
        public String TEN_KH { get; set; }
        public int GIO_VAO { get; set; }
        public int GIO_ROI { get; set; }
        public DateTime NGAY_VAO { get; set; }
        public DateTime NGAY_ROI { get; set; }
        public decimal TIEN_COC { get; set; }
    }
}
