using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class BookingService:IBookingService
    {
        private DatabaseContext _db;
        public BookingService(DatabaseContext db)
        {
            _db = db;
        }

        public string capNhatTienCocVaTrangThai(string ma_don_dat)
        {
            var donDatPhong = _db.DonDatPhongs.ToList().SingleOrDefault(p => p.Madd == ma_don_dat);
            // Cap nhat so tien coc va trang thai cua don dat

            try
            {
                donDatPhong.SoTienCoc = donDatPhong.TongTien / 2;
                donDatPhong.TrangThai = "Đã chuyển cọc";

                _db.Update(donDatPhong);
                _db.SaveChanges();
                return "success";
            } catch(SqlException e)
            {
                return e.Message;
            }
             
        }

        public List<DonDatPhongView> donDatPhongs()
        {
            return _db.DonDatPhongViews.FromSqlRaw("[dbo].[sp_FindListDanhSachDatPhong]").ToList();
        }
    }
}
