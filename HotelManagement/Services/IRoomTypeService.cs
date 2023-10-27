using System;
using HotelManagement.ViewModels;

namespace HotelManagement.Services
{
    public interface IRoomTypeService
    {
        public LoaiPhongView timLoaiPhong(string ma_lp);
    }
}
