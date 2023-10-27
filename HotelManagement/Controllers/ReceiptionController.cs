using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HotelManagement.Controllers
{
    [Route("receiption")]

    public class ReceiptionController : Controller
    {
        private IBaseRepository<HoaDon> _hoaDonRepo;
        private IBaseRepository<TaiKhoan> _taiKhoanRepo;
        private IBaseRepository<DonDatPhong> _donDatPhongRepo;
        private IBaseRepository<Phong> _phongRepo;
        private IBaseRepository<ChiTietDatPhong> _chiTietDatPhongRepo;
        private ICheckOutService _checkOutService;
        public ReceiptionController(IBaseRepository<HoaDon> hoaDonRepo, IBaseRepository<TaiKhoan> taiKhoanRepo,
            IBaseRepository<DonDatPhong> donDatPhongRepo, ICheckOutService checkOutService,
            IBaseRepository<ChiTietDatPhong> chiTietDatPhongRepo, IBaseRepository<Phong> phongRepo)
        {
            _hoaDonRepo = hoaDonRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _donDatPhongRepo = donDatPhongRepo;
            _checkOutService = checkOutService;
            _chiTietDatPhongRepo = chiTietDatPhongRepo;
            _phongRepo = phongRepo;
        }
        // GET: /<controller>/
        [Route("index")]
        public IActionResult Index(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Debug.WriteLine("Message: " + message);
                ViewBag.message = message;
            }

            HoaDon hd = new HoaDon();
            ViewBag.hoaDons = _hoaDonRepo.GetAll().ToList();
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(string ma_don_dat_hoadon, string tong_tien_hoadon, string phu_thu_hoadon, string ghi_chu_hoadon, string trang_thai_hoadon,
                                    string ma_ctdp_hoadon, string phong_so_hoadon, string gio_ra_hoadon)
        {
            try
            {
                var hoaDon = new HoaDon();
                hoaDon.Mahd = "HD" + PrimaryKeyHelper.RandomString(3);
                hoaDon.Httt = "Tiền mặt";
                hoaDon.MaDonDat = ma_don_dat_hoadon;
                hoaDon.TongTien = Convert.ToDecimal(tong_tien_hoadon);
                hoaDon.MaTaiKhoan = "QL001";
                hoaDon.PhuThu = Convert.ToDecimal(phu_thu_hoadon);
                hoaDon.GhiChu = ghi_chu_hoadon;
                hoaDon.TrangThai = trang_thai_hoadon;

                _hoaDonRepo.Insert(hoaDon);
                _hoaDonRepo.Save();


                var ctdp = _chiTietDatPhongRepo.GetAll().ToList().SingleOrDefault(i => i.MaChiTietDatPhong == ma_ctdp_hoadon);
                ctdp.TrangThai = "Đã trả phòng";
                ctdp.GioRa = Convert.ToInt32(gio_ra_hoadon);

                _chiTietDatPhongRepo.Update(ctdp);
                _chiTietDatPhongRepo.Save();

                int phongSo = Convert.ToInt32(phong_so_hoadon);
                var phong = _phongRepo.GetAll().ToList().SingleOrDefault(i => i.PhongSo == phongSo);
                phong.TinhTrang = "Sẵn sàng";
                _phongRepo.Update(phong);
                _phongRepo.Save();


                return RedirectToAction("index", "room", new { message = "create_receiption_success" });
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(String ma_hd)
        {
            var hoa_don = _hoaDonRepo.GetAll().SingleOrDefault(i => i.Mahd == ma_hd);
            return new JsonResult(hoa_don);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteReceiption(String ma_hd)
        {
            var hoa_don = _hoaDonRepo.GetAll().SingleOrDefault(i => i.Mahd == ma_hd);
            _hoaDonRepo.Delete(hoa_don.Mahd);

            try
            {
                _hoaDonRepo.Save();
                return RedirectToAction("index", new { message = "delete_receiption_success" });
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("index", new { message = "delete_receiption_fail" });
            }
        }

        [HttpGet]
        [Route("find_checkout_view_by_phso")]
        public IActionResult FindCheckOutViewByPhso(int phongso)
        {
            return new JsonResult(_checkOutService.findCheckOutViewByPhongso(phongso));
        }

        [HttpPost]
        [Route("kiem_tra_phu_thu")]
        public IActionResult KiemTraPhuThu(int phongso, int giovao, int giora)
        {
            return new JsonResult(_checkOutService.kiemTraPhuThu(phongso, giovao, giora));
        }

        [HttpPost]
        [Route("tim_phieu_dich_vu_by_mactdp")]
        public IActionResult TimPhieuDichVuSuDung(string ma_ctdp)
        {
            return new JsonResult(_checkOutService.timPhieuDichVuByMactdp(ma_ctdp));
        }

        [HttpPost]
        [Route("tinh_tong_tien_phieu_dich_vu_by_mactdp")]
        public IActionResult TinhTongTienPhieuDichVuSuDung(string ma_ctdp)
        {
            return new JsonResult(_checkOutService.tinhTongTienCacDichVuSuDung(ma_ctdp));
        }
    }
}
