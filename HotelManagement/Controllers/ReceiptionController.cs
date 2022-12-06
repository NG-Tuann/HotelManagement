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
    [Route("receiption")]

    public class ReceiptionController : Controller
    {
        private IBaseRepository<HoaDon> _hoaDonRepo;
        private IBaseRepository<TaiKhoan> _taiKhoanRepo;
        private IBaseRepository<DonDatPhong> _donDatPhongRepo;
        public ReceiptionController(IBaseRepository<HoaDon> hoaDonRepo, IBaseRepository<TaiKhoan> taiKhoanRepo, IBaseRepository<DonDatPhong> donDatPhongRepo)
        {
            _hoaDonRepo = hoaDonRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _donDatPhongRepo = donDatPhongRepo;
        }
        // GET: /<controller>/
        [Route("")]
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
    }
}
