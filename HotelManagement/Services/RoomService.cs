using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HotelManagement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class RoomService: IRoomService
    {
        private DatabaseContext _db;
        public RoomService(DatabaseContext db)
        {
            _db = db;
        }

        public List<Phong> timPhongTrong(DateTime ngay_bd, DateTime ngay_kt)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@start_date",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ngay_bd
                        },
                        new SqlParameter() {
                            ParameterName = "@end_date",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ngay_kt
                        }};
            return _db.Phongs.FromSqlRaw("[dbo].[sp_FilterByDate] @start_date, @end_date", param).ToList();
            
        }

        public decimal? tinhGiaPhongTheoNgayTuanThang(string ngay_bd, string ngay_kt, int[] phong_so)
        {

            DateTime sDate = DateTime.ParseExact(ngay_bd, "dd/MM/yyyy",
                                         System.Globalization.CultureInfo.InvariantCulture);

            DateTime eDate = DateTime.ParseExact(ngay_kt, "dd/MM/yyyy",
                                         System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan stay = eDate - sDate;

            int stayDay = stay.Days;

            Debug.WriteLine("So ngay o: " + stayDay);

            decimal? giaPhong = 0;

            for (int i = 0; i < phong_so.Length; i++)
            {
                int phongSo = phong_so[i];
                var phong = _db.Phongs.ToList().SingleOrDefault(i => i.PhongSo == phongSo);

                // Tinh gia phong theo ngay tuan thang

                if (stayDay < 7)
                {
                    giaPhong += phong.MaLpNavigation.MaGiaNavigation.GiaTheoNgay * stayDay;
                    Debug.WriteLine("O theo ngay");
                }
                else if (stayDay < 30)
                {
                    giaPhong += phong.MaLpNavigation.MaGiaNavigation.GiaTheoTuan * stayDay;
                    Debug.WriteLine("O theo tuan");
                }
                else
                {
                    giaPhong += phong.MaLpNavigation.MaGiaNavigation.GiaTheoThang * stayDay;
                    Debug.WriteLine("O theo thang");
                }
            }
            return giaPhong;
        }
    }
}
