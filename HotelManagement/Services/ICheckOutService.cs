using System;
using System.Collections.Generic;
using HotelManagement.ViewModels;

namespace HotelManagement.Services
{
    public interface ICheckOutService
    {
        public CheckOutView findCheckOutViewByPhongso(int phongSo);
        public PhuThu kiemTraPhuThu(int phongSo, int gioVao, int gioRa);
        public List<PhieuDichVuView> timPhieuDichVuByMactdp(string ma_ctdp);
        public decimal tinhTongTienCacDichVuSuDung(string ma_ctdp);
    }
}
