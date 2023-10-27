using System;
using System.Collections.Generic;
using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.Services
{
    public interface IBookingDetailService
    {
        public List<ChiTietDatPhongView> tim_chi_tiet_dat_phong_theo_maphong(string ma_phong);
        public List<ChiTietDatPhongView> tim_chi_tiet_dat_phong_theo_checkin(DateTime checkin);
        public List<ChiTietDatPhongView> tim_chi_tiet_dat_phong_theo_madondat(string ma_don_dat);
        public string cap_nhat_trang_thai_ctdp(string ma_ct_dp);
        public CheckInView tim_chi_tiet_dat_phong_theo_mactdp(string ma_ct_dp);
        public List<ChiTietDatPhongView> tim_tatca_chi_tiet_dat_phong();
        public int totalGuestStay(string ma_ctdp);
    }
}
