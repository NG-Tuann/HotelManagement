using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace HotelManagement.Services
{
    public class BookingDetailService: IBookingDetailService
    {
        private DatabaseContext _db;
        public BookingDetailService(DatabaseContext db)
        {
            _db = db;
        }

        public List<ChiTietDatPhongView> tim_tatca_chi_tiet_dat_phong()
        {
            return _db.ChiTietDatPhongViews.FromSqlRaw("[dbo].[sp_FindAllChiTietDatPhong]").ToList();
        }

        public List<ChiTietDatPhongView> tim_chi_tiet_dat_phong_theo_checkin(DateTime checkin)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@CheckIn",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = checkin
                        }};
            return _db.ChiTietDatPhongViews.FromSqlRaw("[dbo].[sp_FindListChiTietDatPhongByCheckIn] @CheckIn", param).ToList();
        }

        public List<ChiTietDatPhongView> tim_chi_tiet_dat_phong_theo_madondat(string ma_don_dat)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@MaDonDat",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 5,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ma_don_dat
                        }};
            return _db.ChiTietDatPhongViews.FromSqlRaw("[dbo].[sp_FindListChiTietDatPhongByMaDonDat] @MaDonDat", param).ToList();
        }

        public List<ChiTietDatPhongView> tim_chi_tiet_dat_phong_theo_maphong(string ma_phong)
        {
            int phong_so = Convert.ToInt32(ma_phong);
            var phong = _db.Phongs.ToList().SingleOrDefault(i => i.PhongSo == phong_so);
            string maPhong = phong.Maphong;

            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@MaPhong",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 5,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = maPhong
                        }};
            return _db.ChiTietDatPhongViews.FromSqlRaw("[dbo].[sp_FindListChiTietDatPhongByMaPhong] @MaPhong", param).ToList();
        }

        public CheckInView tim_chi_tiet_dat_phong_theo_mactdp(string ma_ct_dp)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@MaCTDP",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 5,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ma_ct_dp
                        }};
            var result = _db.CheckInViews.FromSqlRaw("[dbo].[sp_FindListChiTietDatPhongByCTDD] @MaCTDP", param).ToList();
            if(result.Count >0)
            {
                return result[0];
            } else
            {
                return null;
            }
        }

        public string cap_nhat_trang_thai_ctdp(string ma_ct_dp)
        {
            try
            {
                var ctdp = _db.ChiTietDatPhongs.ToList().SingleOrDefault(i => i.MaChiTietDonDat == ma_ct_dp);
                if(ctdp !=null)
                {
                    ctdp.TrangThai = "<i><b>Đã nhận phòng</b></i>  <i class='fa fa-check text-success'></i>";
                    _db.ChiTietDatPhongs.Update(ctdp);
                    _db.SaveChanges();

                    var phong = _db.Phongs.ToList().SingleOrDefault(i => i.Maphong == ctdp.MaPhong);
                    if(phong !=null) {
                        phong.TinhTrang = "Khách đang ở";
                        _db.Phongs.Update(phong);
                        _db.SaveChanges();
                        return "Nhận phòng thành công";
                    }
                    else
                    {
                        return "Nhận phòng ko thành công";
                    }
                }
                else
                {
                    return "Nhận phòng ko thành công";
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
                return "Nhận phòng ko thành công";
            }
        }
    }
}
