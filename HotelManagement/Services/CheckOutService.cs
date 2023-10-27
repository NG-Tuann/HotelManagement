using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class CheckOutService: ICheckOutService
    {
        private DatabaseContext _db;
        public CheckOutService(DatabaseContext db)
        {
            _db = db;
        }

        public CheckOutView findCheckOutViewByPhongso(int phongSo)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@Phso",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = phongSo
                        }};
            return _db.CheckOutViews.FromSqlRaw("[dbo].[sp_findCheckOutInfoByPhongso] @Phso", param).ToList()[0];
        }

        public PhuThu kiemTraPhuThu(int phongSo, int gioVao, int gioRa)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PHONG_SO",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = phongSo
                        },
                        new SqlParameter() {
                            ParameterName = "@GIO_VAO",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = gioVao
                        },
                        new SqlParameter() {
                            ParameterName = "@GIO_RA",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = gioRa
                        }
            };
            return _db.PhuThus.FromSqlRaw("[dbo].[sp_TinhPhuThu] @PHONG_SO, @GIO_VAO, @GIO_RA", param).ToList()[0];
        }

        public List<PhieuDichVuView> timPhieuDichVuByMactdp(string ma_ctdp)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@ma_ctdp",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 5,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ma_ctdp
                        }};
            return _db.PhieuDichVuViews.FromSqlRaw("[dbo].[sp_FindAllPhieuDichVuByCTDP] @ma_ctdp", param).ToList();
        }

        public decimal tinhTongTienCacDichVuSuDung(string ma_ctdp)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@ma_ctdp",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 5,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ma_ctdp
                        }};
            return _db.PhieuDichVuViews.FromSqlRaw("[dbo].[sp_FindAllPhieuDichVuByCTDP] @ma_ctdp", param).ToList().Sum(i => i.THANH_TIEN);
        }
    }
}
