using System;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface ICustomerService
    {
        public KhachHang kiemTraKhachCu(string cmnd);
    }
}
