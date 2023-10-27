using System;
using System.Linq;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class RoomTypeService: IRoomTypeService
    {
        private DatabaseContext _db;
        public RoomTypeService(DatabaseContext db)
        {
            _db = db;
        }

        public LoaiPhongView timLoaiPhong(string ma_lp)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@Malp",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 5,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ma_lp
                        }};
            return _db.LoaiPhongViews.FromSqlRaw("[dbo].[sp_findLoaiPhongByMalp] @Malp", param).ToList()[0];
        }
    }
}
