using System;
using System.Linq;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class CustomerService: ICustomerService
    {
        private DatabaseContext _db;
        public CustomerService(DatabaseContext db)
        {
            _db = db;
        }

        public KhachHang kiemTraKhachCu(string cmnd)
        {
            if(cmnd !=null)
            {
                if (cmnd.Length > 0)
                {
                    var khachHang = _db.KhachHangs.ToList().SingleOrDefault(i => i.Cmnd.Trim().Equals(cmnd.Trim()));
                    return khachHang;
                }
            }
            return null;
        }
    }
}
