using System;
namespace HotelManagement.ViewModels
{
    public class CheckInView
    {
        public decimal TONG_TIEN { get; set; }
        public DateTime CHECK_IN { get; set; }
        public DateTime CHECK_OUT { get; set; }
        public int GIO_RA { get; set; }
        public decimal TIEN_COC { get; set; }
        public string GHI_CHU { get; set; }
        public string SO_CAN_CUOC { get; set; }
        public string LOAI_PHONG { get; set; }
        public int PHONG_SO { get; set; }
    }
}
