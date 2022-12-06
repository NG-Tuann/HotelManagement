using System;
using System.Linq;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class CustomerService: ICustomerService
    {
        private DatabaseContext _db;
        public CustomerService(DatabaseContext db)
        {
            _db = db;
        }

        public KhachHangCuView kiemTraKhachCu(string cmnd)
        {
            if(cmnd !=null )
            {
                if (cmnd.Trim().Length == 12)
                {
                    var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@cmnd",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 12,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = cmnd
                        }};
                    int result = _db.KhachHangCuViews.FromSqlRaw("[dbo].[sp_timKhachCu] @cmnd", param).ToList().Count;
                    if(result >0)
                    {
                        return _db.KhachHangCuViews.FromSqlRaw("[dbo].[sp_timKhachCu] @cmnd", param).ToList()[0];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
