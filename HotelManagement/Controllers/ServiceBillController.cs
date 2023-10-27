using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("service_bill")]
    public class ServiceBillController : Controller
    {
        private IBaseRepository<PhieuDichVu> _phieuDichVuRepo;

        public ServiceBillController(IBaseRepository<PhieuDichVu> phieuDichVuRepo)
        {
            _phieuDichVuRepo = phieuDichVuRepo;
        }

        // GET: /<controller>/
        [Route("create")]
        [HttpPost]
        public IActionResult Create(string ma_dv, string ma_ctdp, string so_luong, string gia, string thanh_tien)
        {
            try
            {
                var phieu_dich_vu = new PhieuDichVu();

                phieu_dich_vu.MaDv = ma_dv;
                phieu_dich_vu.MaCtdp = ma_ctdp;
                phieu_dich_vu.SoLuong = Convert.ToInt32(so_luong);
                phieu_dich_vu.Gia = Convert.ToDecimal(gia);
                phieu_dich_vu.ThanhTien = Convert.ToDecimal(thanh_tien);

                _phieuDichVuRepo.Insert(phieu_dich_vu);
                _phieuDichVuRepo.Save();

                return new JsonResult("Success");
            } catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}
