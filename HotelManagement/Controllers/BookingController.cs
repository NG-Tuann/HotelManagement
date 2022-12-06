using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Helpers;
using HotelManagement.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("booking")]
    public class BookingController : Controller
    {
        private IBaseRepository<DonDatPhong> _donDatPhongRepo;
        private IBaseRepository<ChiTietDatPhong> _chiTietDatPhongRepo;
        private IBaseRepository<KhachHang> _khachHangRepo;
        private IBaseRepository<ChiTietKhachO> _chiTietKhachO;
        private IBaseRepository<Phong> _phongRepo;
        private IBookingService _bookingService;

        public BookingController(IBaseRepository<DonDatPhong> donDatPhongRepo, IBaseRepository<ChiTietDatPhong> chiTietDatPhongRepo,
                                 IBaseRepository<KhachHang> khachHangRepo, IBaseRepository<ChiTietKhachO> chiTietKhachO,
                                 IBaseRepository<Phong> phongRepo, IBookingService bookingService)
        {
            _donDatPhongRepo = donDatPhongRepo;
            _chiTietDatPhongRepo = chiTietDatPhongRepo;
            _khachHangRepo = khachHangRepo;
            _chiTietKhachO = chiTietKhachO;
            _phongRepo = phongRepo;
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("capNhatTienCoc")]
        public IActionResult CapNhatTienCoc(string ma_don_dat)
        {
            return new JsonResult(_bookingService.capNhatTienCocVaTrangThai(ma_don_dat));
        }

        [HttpGet]
        [Route("findall")]
        public IActionResult FindAll()
        {
            var result = _bookingService.donDatPhongs();
            if(result.Count >0)
            {
                return new JsonResult(result);
            }
            return new JsonResult(null);
        }

        // GET: /<controller>/
        [HttpPost]
        [Route("create")]
        public IActionResult Index(String tong_tien,String tien_coc,
                                   String ngay_vao, String vao_luc, String ngay_roi, String roi_luc, String phong_so,
                                   String[] so_can_cuoc_kh, String[] ho_ten_kh, String[] dia_chi_kh, String[] email_kh,
                                   String[] ngay_sinh_kh, String[] sdt_kh, String[] gioi_tinh_kh, String[] quoc_gia_kh)
        {
            int soLuongKhach = so_can_cuoc_kh.ToList().Count;

            var danhSachKhachHang = new List<KhachHang>();

            // Them cac khach hang o
            for (int i = 0; i < soLuongKhach; i++)
            {
                // So cmnd
                string cmnd_khach = so_can_cuoc_kh[i];
                var is_khach_cu = _khachHangRepo.GetAll().ToList().SingleOrDefault(i => i.Cmnd.ToString().Equals(cmnd_khach));

                if(is_khach_cu !=null)
                {
                    danhSachKhachHang.Add(is_khach_cu);
                }
                else
                {
                    // Dua cac thuoc tinh nhan ve vao khach hang
                    var khach_hang = new KhachHang();

                    khach_hang.Makh = "KH" + PrimaryKeyHelper.RandomString(3);
                    khach_hang.Cmnd = so_can_cuoc_kh[i];
                    khach_hang.TenKh = ho_ten_kh[i];

                    string ngaySinh = ngay_sinh_kh[i];

                    if(ngay_sinh_kh[i].Length > 10)
                    {
                        ngaySinh = FormatDateTime.formatDate(ngay_sinh_kh[i]);
                    }
                    DateTime dob = DateTime.ParseExact(ngaySinh, "dd/MM/yyyy",
                                             System.Globalization.CultureInfo.InvariantCulture);
                    
                    khach_hang.NgaySinh = dob;
                    khach_hang.Email = email_kh[i];
                    if (gioi_tinh_kh[i] == "nam")
                    {
                        khach_hang.GioiTinh = 1;
                    }
                    else if (gioi_tinh_kh[i] == "nữ")
                    {
                        khach_hang.GioiTinh = 2;
                    }
                    else
                    {
                        khach_hang.GioiTinh = 0;
                    }

                    khach_hang.QuocTich = quoc_gia_kh[i];
                    khach_hang.Sdt = sdt_kh[i];

                    danhSachKhachHang.Add(khach_hang);

                    _khachHangRepo.Insert(khach_hang);
                }
            }

            int numberOfCustomerInserted = _khachHangRepo.Save();

            Debug.WriteLine("So khach hang: "+numberOfCustomerInserted);

            // Them vao don dat phong
            var don_dat_phong = new DonDatPhong();

            don_dat_phong.Madd = "DD" + PrimaryKeyHelper.RandomString(3);
            don_dat_phong.TongTien = Convert.ToDecimal(tong_tien);
            don_dat_phong.MaTk = "QL001";
            don_dat_phong.GhiChu = "Ok";

            var today = DateTime.Today;
            
            DateTime ngay_tao = DateTime.ParseExact(today.ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                                         System.Globalization.CultureInfo.InvariantCulture);

            don_dat_phong.NgayTao = ngay_tao;
            don_dat_phong.SoTienCoc = Convert.ToDecimal(tien_coc);

            if(don_dat_phong.SoTienCoc == (don_dat_phong.TongTien / 2))
            {
                don_dat_phong.TrangThai = "Đã chuyển cọc";
            }
            else
            {
                don_dat_phong.TrangThai = "Đợi chuyển cọc";
            }

            don_dat_phong.MaKhDat = danhSachKhachHang[danhSachKhachHang.Count-1].Makh;

            _donDatPhongRepo.Insert(don_dat_phong);
            _donDatPhongRepo.Save();

            // Neu dat nhieu phong trong 1 don dat

            if(phong_so.Contains('-'))
            {
                string[] phongs = phong_so.Split(" - ");
                for(int i =0;i<phongs.Length;i++)
                {
                    // Them vao chi tiet don dat
                    // Tao 1 chi tiet don dat

                    var chi_tiet_dat_phong = new ChiTietDatPhong();

                    chi_tiet_dat_phong.MaDonDatPhong = don_dat_phong.Madd;

                    chi_tiet_dat_phong.MaChiTietDonDat = "DP" + PrimaryKeyHelper.RandomString(3);

                    int phongSo = Convert.ToInt32(phongs[i]);

                    var phong = _phongRepo.GetAll().ToList().SingleOrDefault(i => i.PhongSo == phongSo);

                    chi_tiet_dat_phong.MaPhong = phong.Maphong;

                    DateTime ngayThueBd = DateTime.ParseExact(ngay_vao, "dd/MM/yyyy",
                                                 System.Globalization.CultureInfo.InvariantCulture);

                    DateTime ngayThueKt = DateTime.ParseExact(ngay_roi, "dd/MM/yyyy",
                                                 System.Globalization.CultureInfo.InvariantCulture);
                    chi_tiet_dat_phong.NgayThueBd = ngayThueBd;
                    chi_tiet_dat_phong.NgayThueKt = ngayThueKt;
                    chi_tiet_dat_phong.TrangThai = "Đợi nhận phòng";
                    chi_tiet_dat_phong.GioVao = Convert.ToInt32(vao_luc);
                    chi_tiet_dat_phong.GioRa = Convert.ToInt32(roi_luc);

                    _chiTietDatPhongRepo.Insert(chi_tiet_dat_phong);
                    _chiTietDatPhongRepo.Save();
                }
            }
            // Neu dat 1 phong trong 1 don dat
            else
            {
                // Them vao chi tiet dat phong

                // Tao 1 chi tiet don dat

                var chi_tiet_dat_phong = new ChiTietDatPhong();

                chi_tiet_dat_phong.MaDonDatPhong = don_dat_phong.Madd;

                chi_tiet_dat_phong.MaChiTietDonDat = "DP" + PrimaryKeyHelper.RandomString(3);

                int phongSo = Convert.ToInt32(phong_so);

                var phong = _phongRepo.GetAll().ToList().SingleOrDefault(i => i.PhongSo == phongSo);

                chi_tiet_dat_phong.MaPhong = phong.Maphong;

                DateTime ngayThueBd = DateTime.ParseExact(ngay_vao, "dd/MM/yyyy",
                                             System.Globalization.CultureInfo.InvariantCulture);

                DateTime ngayThueKt = DateTime.ParseExact(ngay_roi, "dd/MM/yyyy",
                                             System.Globalization.CultureInfo.InvariantCulture);
                chi_tiet_dat_phong.NgayThueBd = ngayThueBd;
                chi_tiet_dat_phong.NgayThueKt = ngayThueKt;
                chi_tiet_dat_phong.TrangThai = "Đợi nhận phòng";
                chi_tiet_dat_phong.GioVao = Convert.ToInt32(vao_luc);
                chi_tiet_dat_phong.GioRa = Convert.ToInt32(roi_luc);

                _chiTietDatPhongRepo.Insert(chi_tiet_dat_phong);
                _chiTietDatPhongRepo.Save();
            }
            // Them vao chi tiet khach o

            for (int i = 0; i < danhSachKhachHang.Count(); i++)
            {
                var chi_tiet_khach_o = new ChiTietKhachO();

                chi_tiet_khach_o.MaDonDat = don_dat_phong.Madd;
                chi_tiet_khach_o.MaKhachO = danhSachKhachHang[i].Makh;

                _chiTietKhachO.Insert(chi_tiet_khach_o);
            }
            _chiTietKhachO.Save();
            
            

            return RedirectToAction("index","room");
        }
    }
}
