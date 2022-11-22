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
    }
}
