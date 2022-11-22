using System;
using System.Collections.Generic;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IRoomService
    {
        public List<Phong> timPhongTrong(DateTime ngay_bd, DateTime ngay_kt);
    }
}
