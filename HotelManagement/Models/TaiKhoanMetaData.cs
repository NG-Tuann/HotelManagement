using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Models
{
    // Chi ra class employee se dung nhung validation dc khai bao trong EmployeeMetaData
    [ModelMetadataType(typeof(TaiKhoanMetaData))]
    public partial class TaiKhoan
    {

    }
    public class TaiKhoanMetaData
    {
        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public string TenNv { get; set; }

        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        
        public string TaiKhoan1 { get; set; }

        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        [MaxLength(12)]
        public string Cmnd { get; set; }

        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public int? GioiTinh { get; set; }

        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public string ChucVu { get; set; }
    }
}
