using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Helpers;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("chi_tiet_dat_phong")]
    public class BookingDetailController : Controller
    {
        private IBookingDetailService _bookingDetailService;

        public BookingDetailController(IBookingDetailService bookingDetailService)
        {
            _bookingDetailService = bookingDetailService;
        }

        [HttpPost]
        [Route("tong_khach_o")]
        public IActionResult TongKhachO(string ma_ctdp)
        {
            return new JsonResult(_bookingDetailService.totalGuestStay(ma_ctdp));
        }


        [HttpGet]
        [Route("tim_tat_ca_chitietdondat")]
        public IActionResult TimTatCa()
        {
            var chiTietDonDats = _bookingDetailService.tim_tatca_chi_tiet_dat_phong();
            return new JsonResult(chiTietDonDats.ToList());
        }

        // GET: /<controller>/
        [HttpGet]
        [Route("tim_theo_checkin")]
        public IActionResult TimTheoCheckIn(String check_in)
        {
            if(check_in !=null)
            {
                DateTime checkIn = DateTime.ParseExact(check_in, "dd/MM/yyyy",
                                         System.Globalization.CultureInfo.InvariantCulture);
                var chiTietDonDats = _bookingDetailService.tim_chi_tiet_dat_phong_theo_checkin(checkIn);
                return new JsonResult(chiTietDonDats.ToList());
            }
            return null;
        }

        [HttpGet]
        [Route("tim_theo_maphong")]
        public IActionResult TimTheoMaPhong(String ma_phong)
        {
            var chiTietDonDats = _bookingDetailService.tim_chi_tiet_dat_phong_theo_maphong(ma_phong);
            return new JsonResult(chiTietDonDats.ToList());
        }

        [HttpPost]
        [Route("tim_theo_madondat")]
        public IActionResult TimTheoMaDonDat(String ma_don_dat)
        {
            var chiTietDonDats = _bookingDetailService.tim_chi_tiet_dat_phong_theo_madondat(ma_don_dat);
            return new JsonResult(chiTietDonDats.ToList());
        }

        [HttpPost]
        [Route("tim_theo_ma_ct_dondat")]
        public IActionResult TimTheoMaCtDonDat(String ma_ct_dondat)
        {
            var chiTietDonDat = _bookingDetailService.tim_chi_tiet_dat_phong_theo_mactdp(ma_ct_dondat);
            return new JsonResult(chiTietDonDat);
        }

        [HttpPost]
        [Route("nhan_phong_theo_ma_ct_dondat")]
        public IActionResult NhanPhongTheoMaCtDonDat(String ma_ct_dondat)
        {
            string result = _bookingDetailService.cap_nhat_trang_thai_ctdp(ma_ct_dondat);
            return new JsonResult(result);
        }
    }
}
