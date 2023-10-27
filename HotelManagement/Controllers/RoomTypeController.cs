using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("roomtype")]
    public class RoomTypeController : Controller
    {
        private IBaseRepository<LoaiPhong> _loaiPhongRepo;
        private IBaseRepository<GiaPhong> _giaPhongRepo;
        private IBaseRepository<Phong> _phongRepo;
        private IRoomTypeService _roomTypeService;
        public RoomTypeController(IBaseRepository<LoaiPhong> loaiPhongRepo, IBaseRepository<GiaPhong> giaPhongRepo, IBaseRepository<Phong> phongRepo, IRoomTypeService roomTypeService)
        {
            _loaiPhongRepo = loaiPhongRepo;
            _giaPhongRepo = giaPhongRepo;
            _phongRepo = phongRepo;
            _roomTypeService = roomTypeService;
        }
        // GET: /<controller>/
        [Route("")]
        [Route("index")]
        public IActionResult Index(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Debug.WriteLine("Message: "+message);
                ViewBag.message = message;
            }
            ViewBag.loaiPhongs = _loaiPhongRepo.GetAll().ToList();
            return View();
        }

        [HttpGet]
        [Route("update")]
        public IActionResult Update(String ma_lp)
        {
            var loai_phong = _roomTypeService.timLoaiPhong(ma_lp);
            return new JsonResult(loai_phong);
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(String ma_lp)
        {
            var loai_phong = _loaiPhongRepo.GetAll().SingleOrDefault(i => i.Malp == ma_lp);
            return new JsonResult(loai_phong);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteRoomType(String ma_lp)
        {
            var loai_phong = _loaiPhongRepo.GetAll().SingleOrDefault(i => i.Malp == ma_lp);
            _loaiPhongRepo.Delete(loai_phong.Malp);

            try
            {
                _loaiPhongRepo.Save();
                return RedirectToAction("index", new { message = "delete_room_type_success" });
            } catch(SqlException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("index", new { message = "delete_room_type_fail" });
            }
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(String update_roomtype_id, String loai_phong, String khong_gian, String so_giuong, String so_nguoi,
                                    String gia_theo_gio, String gia_theo_ngay, String gia_theo_tuan, String gia_theo_thang,
                                    String ngay_hieu_luc_bd, String ngay_hieu_luc_kt, String update_price_id,
                                    String qua_1h, String qua_2h, String truoc_3h, String truoc_4h)
        {
            // Tao moi cai dat gia cho loai phong
            var giaPhongUpdate = _giaPhongRepo.GetAll().SingleOrDefault(i => i.Magia == update_price_id);

            giaPhongUpdate.GiaTheoGio = Convert.ToDecimal(gia_theo_gio);
            giaPhongUpdate.GiaTheoNgay = Convert.ToDecimal(gia_theo_ngay);
            giaPhongUpdate.GiaTheoTuan = Convert.ToDecimal(gia_theo_tuan);
            giaPhongUpdate.GiaTheoThang = Convert.ToDecimal(gia_theo_thang);

            String sDate = ngay_hieu_luc_bd;
            String eDate = ngay_hieu_luc_kt;
            if (sDate.Length > 10)
            {
                sDate = FormatDateTime.formatDate(ngay_hieu_luc_bd);
                Debug.WriteLine(sDate);
                Debug.WriteLine(eDate);
            }

            if(eDate.Length > 10)
            {
                eDate = FormatDateTime.formatDate(ngay_hieu_luc_kt);
                Debug.WriteLine(eDate);
            }

            try
            {
               
                DateTime startDate = DateTime.ParseExact(sDate, "dd/MM/yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(eDate, "dd/MM/yyyy",
                                           System.Globalization.CultureInfo.InvariantCulture);
                giaPhongUpdate.NgayHieuLucBd = startDate;
                giaPhongUpdate.NgayHieuLucKt = endDate;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            giaPhongUpdate.Qua1h = Convert.ToDecimal(qua_1h);
            giaPhongUpdate.Qua2h = Convert.ToDecimal(qua_2h);
            giaPhongUpdate.Truoc3h = Convert.ToDecimal(truoc_3h);
            giaPhongUpdate.Truoc4h = Convert.ToDecimal(truoc_4h);

            // Tao moi loai phong va gan cai dat gia
            var loaiPhongUpdate = _loaiPhongRepo.GetAll().SingleOrDefault(i => i.Malp == update_roomtype_id);

            loaiPhongUpdate.LoaiPhong1 = loai_phong;
            loaiPhongUpdate.KhongGian = khong_gian;
            loaiPhongUpdate.SoGiuong = Convert.ToInt32(so_giuong);
            loaiPhongUpdate.SoNguoi = Convert.ToInt32(so_nguoi);
            loaiPhongUpdate.MaGia = update_price_id;

            _giaPhongRepo.Update(giaPhongUpdate);
            _loaiPhongRepo.Update(loaiPhongUpdate);
            try
            {
                _giaPhongRepo.Save();
                _loaiPhongRepo.Save();
                Debug.WriteLine("Success");
                return RedirectToAction("index", new { message = "update_room_type_success" });

            } catch(SqlException e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine("Update fail");
                return RedirectToAction("index");
            }

        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(String loai_phong, String khong_gian, String so_giuong, String so_nguoi,
                                    String gia_theo_gio, String gia_theo_ngay, String gia_theo_tuan, String gia_theo_thang,
                                    String ngay_hieu_luc_bd, String ngay_hieu_luc_kt,
                                    String qua_1h, String qua_2h, String truoc_3h, String truoc_4h)
        {
            // Tao moi cai dat gia cho loai phong
            var newGiaPhong = new GiaPhong();
            String maGiaPhong = PrimaryKeyHelper.RandomString(5);
            newGiaPhong.Magia = maGiaPhong;
            newGiaPhong.GiaTheoGio = Convert.ToDecimal(gia_theo_gio);
            newGiaPhong.GiaTheoNgay = Convert.ToDecimal(gia_theo_ngay);
            newGiaPhong.GiaTheoTuan = Convert.ToDecimal(gia_theo_tuan);
            newGiaPhong.GiaTheoThang = Convert.ToDecimal(gia_theo_thang);
            try
            {
              
                DateTime startDate = DateTime.ParseExact(ngay_hieu_luc_bd, "dd/MM/yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(ngay_hieu_luc_kt, "dd/MM/yyyy",
                                           System.Globalization.CultureInfo.InvariantCulture);

                newGiaPhong.NgayHieuLucBd = startDate;
                newGiaPhong.NgayHieuLucKt = endDate;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            newGiaPhong.Qua1h = Convert.ToDecimal(qua_1h);
            newGiaPhong.Qua2h = Convert.ToDecimal(qua_2h);
            newGiaPhong.Truoc3h = Convert.ToDecimal(truoc_3h);
            newGiaPhong.Truoc4h = Convert.ToDecimal(truoc_4h);

            // Tao moi loai phong va gan cai dat gia
            var newLoaiPhong = new LoaiPhong();

            newLoaiPhong.Malp = "LP" + PrimaryKeyHelper.RandomString(3);
            newLoaiPhong.LoaiPhong1 = loai_phong;
            newLoaiPhong.KhongGian = khong_gian;
            newLoaiPhong.SoGiuong = Convert.ToInt32(so_giuong);
            newLoaiPhong.SoNguoi = Convert.ToInt32(so_nguoi);
            newLoaiPhong.MaGia = maGiaPhong;

            _giaPhongRepo.Insert(newGiaPhong);
            _loaiPhongRepo.Insert(newLoaiPhong);

            try
            {
                _giaPhongRepo.Save();
                _loaiPhongRepo.Save();
                Debug.WriteLine("Success");
                return RedirectToAction("index", new { message = "create_room_type_success" });

            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine("Insert fail");
                return RedirectToAction("index");
            }

        }

        //public String formatDate(String date)
        //{
        //    String cutDate = date.Substring(0, 10);
        //    string newDate = cutDate.Replace('-', '/');
        //    string[] result = newDate.Split('/');

        //    String dateFormatted = result[2] + "/" + result[1] + "/" + result[0];
        //    return dateFormatted;
        //}
    }
}
