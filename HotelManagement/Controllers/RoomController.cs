using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private IRoomService _roomService;
        // GET: /<controller>/

        public RoomController(IBaseRepository<Phong> phongRebo, IBaseRepository<Tang> tangRepo, IBaseRepository<LoaiPhong> loaiPhongRepo, IRoomService roomService)
        {
            _phongRepo = phongRebo;
            _tangRepo = tangRepo;
            _loaiPhongRepo = loaiPhongRepo;
            _roomService = roomService;
        }

        [Route("index")]
        [Route("~/")]
        [Route("")]
        public IActionResult Index()
        {
            Debug.WriteLine("So luong phong hien tai: "+_phongRepo.GetAll().ToList().Count);
            // Truyen danh sach tang va phong sang view
            ViewBag.tangs = _tangRepo.GetAll().ToList();
            // Truyen danh sach cac loai phong sang view
            ViewBag.loaiPhongs = _loaiPhongRepo.GetAll().ToList();
            // Truyen danh sach phong trong
            return View();
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

                // Truyen danh sach tang va phong sang view
                ViewBag.tangs = _tangRepo.GetAll().ToList();

                // Truyen danh sach cac loai phong sang view
                ViewBag.loaiPhongs = _loaiPhongRepo.GetAll().ToList();

                // Truyen danh sach phong trong sang view
                ViewBag.phongsTrong = pTrongs;

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
            return new JsonResult(phong);
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


    }
}
