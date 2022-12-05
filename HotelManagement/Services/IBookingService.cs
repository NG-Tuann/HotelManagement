using System;
using System.Collections.Generic;
using HotelManagement.ViewModels;

namespace HotelManagement.Services
{
    public interface IBookingService
    {
        public List<DonDatPhongView> donDatPhongs();
        public string capNhatTienCocVaTrangThai(string ma_don_dat);
    }
}
