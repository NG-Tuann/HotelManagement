using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("floor")]
    public class FloorController : Controller
    {
        private IBaseRepository<Tang> _tangRepo;
        private IBaseRepository<Phong> _phongRepo;

        public FloorController(IBaseRepository<Tang> tangRepo, IBaseRepository<Phong> phongRepo)
        {
            _tangRepo = tangRepo;
            _phongRepo = phongRepo;
        }
        // GET: /<controller>/
        [Route("index")]
        public IActionResult Index()
        {
            return RedirectToAction("index","room");
        }

        [Route("create")]
        [HttpPost]
        public IActionResult create(String id, String floor)
        {
            var newFLoor = new Tang();

            newFLoor.Matang = id;
            newFLoor.Tang1 = Convert.ToInt32(floor);
            _tangRepo.Insert(newFLoor);

            try
            {
                int result = _tangRepo.Save();
                if(result > 0)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("500","Error");
                }
            } catch(SqlException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("500", "Error");
            }
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(String floor_id)
        {
            // Tim ve tang
            int floorId = Convert.ToInt32(floor_id);
            Tang xoaTang = _tangRepo.GetAll().SingleOrDefault(i => i.Tang1 == floorId);

            // Xoa danh sach cac phong thuoc tang neu co
            var phongs = xoaTang.Phongs.ToList();

            if(phongs.Count > 0)
            {
                int slPhong = phongs.Count;
                for (int i = 0; i < slPhong; i++)
                {
                    _phongRepo.Delete(phongs[i].Maphong);
                }
                _phongRepo.Save();
            }
            else if(phongs.Count ==1)
            {
                _phongRepo.Delete(phongs[0].Maphong);
                _phongRepo.Save();
            }
            _tangRepo.Delete(xoaTang.Matang);

            try
            {
                if (_tangRepo.Save() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
