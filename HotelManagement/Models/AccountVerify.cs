using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class AccountVerify
    {
        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public string tai_khoan { get; set; }
    }
}
