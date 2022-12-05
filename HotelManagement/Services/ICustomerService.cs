using System;
using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.Services
{
    public interface ICustomerService
    {
        public KhachHangCuView kiemTraKhachCu(string cmnd);
    }
}
