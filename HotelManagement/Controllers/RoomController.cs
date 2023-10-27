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
    [Route("room")]
    public class RoomController : Controller
    {
        private IBaseRepository<Phong> _phongRepo;
        private IBaseRepository<Tang> _tangRepo;
        private IBaseRepository<LoaiPhong> _loaiPhongRepo;
        private IBaseRepository<DichVu> _dichVuRepo;
        private IRoomService _roomService;
        // GET: /<controller>/

        public RoomController(IBaseRepository<Phong> phongRebo, IBaseRepository<Tang> tangRepo, IBaseRepository<LoaiPhong> loaiPhongRepo,
                                IRoomService roomService, IBaseRepository<DichVu> dichVuRepo)
        {
            _phongRepo = phongRebo;
            _tangRepo = tangRepo;
            _loaiPhongRepo = loaiPhongRepo;
            _roomService = roomService;
            _dichVuRepo = dichVuRepo;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Debug.WriteLine("Message: " + message);
                ViewBag.message = message;
            }
            Debug.WriteLine("So luong phong hien tai: "+_phongRepo.GetAll().ToList().Count);
            // Truyen danh sach tang va phong sang view
            ViewBag.tangs = _tangRepo.GetAll().ToList();
            // Truyen danh sach cac loai phong sang view
            ViewBag.loaiPhongs = _loaiPhongRepo.GetAll().ToList();
            // Truyen dang sach cac dich vu
            ViewBag.dichVus = _dichVuRepo.GetAll().ToList();
            // Truyen danh sach phong trong
            return View();
        }

        [HttpGet]
        [Route("filter_room_by_check_in")]
        public IActionResult filterRoomByCheckIn()
        {
            var tangs = _tangRepo.GetAll().ToList();
            for (int i = 0; i < tangs.Count; i++)
            {
                var phongs = tangs[i].Phongs.ToList();
                for (int j = 0; j < phongs.Count; j++)
                {
                    if(!(phongs[j].TinhTrang == "Khách đang ở"))
                    {
                        tangs[i].Phongs.Remove(phongs[j]);
                    }
                }
            }
            ViewBag.tangs = tangs;
            // Truyen danh sach cac loai phong sang view
            ViewBag.loaiPhongs = _loaiPhongRepo.GetAll().ToList();
            // Truyen dang sach cac dich vu
            ViewBag.dichVus = _dichVuRepo.GetAll().ToList();
            // Truyen danh sach phong trong
            return View("index");
        }

        [HttpGet]
        [Route("filter_room_by_date")]
        public IActionResult filterRoomByDate(String start_date, String end_date)
        {
            try
            {
                DateTime sDate = DateTime.ParseExact(start_date, "dd/MM/yyyy",
                                         System.Globalization.CultureInfo.InvariantCulture);

                DateTime eDate = DateTime.ParseExact(end_date, "dd/MM/yyyy",
                                          System.Globalization.CultureInfo.InvariantCulture);
                List<Phong> pTrongs = _roomService.timPhongTrong(sDate, eDate);

                var tangs = _tangRepo.GetAll().ToList();

                // Loc ra nhung phong trong bo di nhung phong da dc dat

                // Neu ko con phong trong se remove di het phong

                if(pTrongs.Count == 0 || pTrongs == null)
                {
                    foreach (var tang in tangs)
                    {
                        tang.Phongs.Clear();
                    }
                }
                else
                {
                    for (int i = 0; i < tangs.Count; i++)
                    {
                        // xoa phong theo duyet nguoc
                        var soLuongPhongOTang = tangs[i].Phongs.Count;
                        for (int j = soLuongPhongOTang-1; j >= 0; j--)
                        {
                            var phong = tangs[i].Phongs.ToList()[j];
                            if (!(pTrongs.Contains(phong)))
                            {
                                tangs[i].Phongs.Remove(phong);
                            }
                        }
                    }
                }

                // Truyen danh sach tang va phong sang view
                ViewBag.tangs = tangs;

                // Truyen danh sach cac loai phong sang view
                ViewBag.loaiPhongs = _loaiPhongRepo.GetAll().ToList();

                // Truyen ngay dat phong sang view
                ViewBag.ngayDat = start_date + " - " + end_date;

                // Truyen dang sach cac dich vu
                ViewBag.dichVus = _dichVuRepo.GetAll().ToList();

                return View("index");
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return View("index");
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(String room_id, String room_number, String floor_number, String room_type_id, String room_status)
        {
            Debug.WriteLine(room_id);
            Debug.WriteLine(room_number);
            Debug.WriteLine(room_type_id);
            Debug.WriteLine(floor_number);
            Debug.WriteLine(room_status);

            int tangThu = Convert.ToInt32(floor_number);
            var tang = _tangRepo.GetAll().SingleOrDefault(i => i.Tang1 == tangThu);

            Debug.WriteLine("Ma tang: " + tang.Matang);

            var newRoom = new Phong();
            newRoom.Maphong = room_id;
            newRoom.TinhTrang = room_status;
            newRoom.MaLp = room_type_id;
            newRoom.MaTang = tang.Matang;
            newRoom.PhongSo = Convert.ToInt32(room_number);

            _phongRepo.Insert(newRoom);

            try
            {
                if(_phongRepo.Save() >0)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("index");
                }
            } catch(SqlException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(String room_id)
        {
            int roomId = Convert.ToInt32(room_id);
            Phong xoaPhong = _phongRepo.GetAll().SingleOrDefault(i => i.PhongSo == roomId);
            _phongRepo.Delete(xoaPhong.Maphong);

            try
            {
                if(_phongRepo.Save() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            } catch(SqlException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("update")]
        public IActionResult Update(String room_id)
        {
            int roomId = Convert.ToInt32(room_id);
            var phong = _phongRepo.GetAll().SingleOrDefault(i => i.PhongSo == roomId);

            var phongUpdate = new Phong();
            phongUpdate.Maphong = phong.Maphong;
            phongUpdate.MaTang = phong.MaTang;
            phongUpdate.MaLp = phong.MaLp;
            phongUpdate.PhongSo = phong.PhongSo;
            phongUpdate.TinhTrang = phong.TinhTrang;

            return new JsonResult(phongUpdate);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(String room_id, String room_number, String floor_number, String room_type_id, String room_status)
        {
            Debug.WriteLine(room_id);
            Debug.WriteLine(room_number);
            Debug.WriteLine(room_type_id);
            Debug.WriteLine(floor_number);
            Debug.WriteLine(room_status);

            var phong = _phongRepo.GetAll().SingleOrDefault(i => i.Maphong == room_id);

            phong.TinhTrang = room_status;
            phong.MaLp = room_type_id;
            phong.MaTang = floor_number;
            phong.PhongSo = Convert.ToInt32(room_number);

            _phongRepo.Update(phong);

            try
            {
                if (_phongRepo.Save() > 0)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("index");
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        [Route("tinh_gia_phong")]
        public IActionResult TinhGiaPhong(string ngay_bd, string ngay_kt, int[] phong_so)
        {
            decimal? gia = _roomService.tinhGiaPhongTheoNgayTuanThang(ngay_bd, ngay_kt, phong_so);
            return new JsonResult(gia);
        }

        [HttpGet]
        [Route("so_luong_khach_chua")]
        public IActionResult TinhGiaPhong(int phongso)
        {
            int soLuongKhach = _roomService.soLuongKhachChua(phongso);
            return new JsonResult(soLuongKhach);
        }
    }
}
