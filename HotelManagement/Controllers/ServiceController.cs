using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace HotelManagement.Controllers
{
    [Route("service")]

    public class ServiceController : Controller
    {
        private IBaseRepository<DichVu> _dichVuRepo;
        public ServiceController(IBaseRepository<DichVu> dichVuRepo)
        {
            _dichVuRepo = dichVuRepo;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Debug.WriteLine("Message: " + message);
                ViewBag.message = message;
            }
            ViewBag.dichVu = _dichVuRepo.GetAll().ToList();
            return View();
        }

        [HttpGet]
        [Route("get_service_by_id")]
        public IActionResult GetServiceById(String ma_dv)
        {
            var dich_vu = _dichVuRepo.GetAll().ToList().SingleOrDefault(i => i.Madv == ma_dv);
            var dichVu = new DichVu();

            dichVu.Madv = dich_vu.Madv;
            dichVu.TenDv = dich_vu.TenDv;
            dichVu.DonGia = dich_vu.DonGia;
            dichVu.NgayTao = dich_vu.NgayTao;
            dichVu.TinhTheo = dich_vu.TinhTheo;
            dichVu.TrangThai = dich_vu.TrangThai;

            return new JsonResult(dichVu);
        }

        [HttpGet]
        [Route("update")]
        public IActionResult Update(String ma_dv)
        {
            var dich_vu = _dichVuRepo.GetAll().ToList().SingleOrDefault(i => i.Madv == ma_dv);
            var dichVu = new DichVu();

            dichVu.Madv = dich_vu.Madv;
            dichVu.TenDv = dich_vu.TenDv;
            dichVu.DonGia = dich_vu.DonGia;
            dichVu.NgayTao = dich_vu.NgayTao;
            dichVu.TinhTheo = dich_vu.TinhTheo;
            dichVu.TrangThai = dich_vu.TrangThai;

            return new JsonResult(dichVu);
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(String ma_dv)
        {
            var dich_vu = _dichVuRepo.GetAll().SingleOrDefault(i => i.Madv == ma_dv);
            return new JsonResult(dich_vu);
        }


        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteService(String ma_dv)
        {
            var dich_vu = _dichVuRepo.GetAll().SingleOrDefault(i => i.Madv == ma_dv);
            _dichVuRepo.Delete(dich_vu.Madv);

            try
            {
                _dichVuRepo.Save();
                return RedirectToAction("index", new { message = "delete_service_success" });
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("index", new { message = "delete_service_fail" });
            }
        }
        //update dich vu
        [HttpPost]
        [Route("update")]
        public IActionResult Update(String service_id, String ten_dich_vu, int don_gia, String don_vi, String trang_thai)
        {
            // Tao moi dich vu
            var dichVuUpdate = _dichVuRepo.GetAll().SingleOrDefault(i => i.Madv == service_id);
            dichVuUpdate.TenDv = ten_dich_vu;
            dichVuUpdate.DonGia = Convert.ToInt32(don_gia); 
            dichVuUpdate.TinhTheo = don_vi;
            dichVuUpdate.TrangThai = trang_thai;
            

            _dichVuRepo.Update(dichVuUpdate);
            try
            {
                _dichVuRepo.Save();
                Debug.WriteLine("Success");
                return RedirectToAction("index", new { message = "update_service_success" });

            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine("Update fail");
                return RedirectToAction("index");
            }

        }

        // create
        [HttpPost]
        [Route("create")]
        public IActionResult Create(String ten_dich_vu, int don_gia, String don_vi, String trang_thai)
        {
            var newDichVu = new DichVu();

            newDichVu.Madv = "DV" + PrimaryKeyHelper.RandomString(3);
            newDichVu.TenDv = ten_dich_vu;
            newDichVu.DonGia = don_gia;
            newDichVu.TinhTheo = don_vi;
            newDichVu.TrangThai = trang_thai;
            newDichVu.NgayTao = DateTime.Today;


            try
            {
                _dichVuRepo.Insert(newDichVu);
                _dichVuRepo.Save();
                Debug.WriteLine("Success");
                return RedirectToAction("index", new { message = "update_service_success" });

            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine("Update fail");
                return RedirectToAction("index");
            }

        }
        public String formatDate(String date)
        {
            String cutDate = date.Substring(0, 10);
            string newDate = cutDate.Replace('-', '/');
            string[] result = newDate.Split('/');

            String dateFormatted = result[2] + "/" + result[1] + "/" + result[0];
            return dateFormatted;
        }
    }

}
