using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Account
    {
        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public string tai_khoan { get; set; }

        //[RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})", ErrorMessage = "Mật khẩu không đáp ứng yêu cầu định dạng ")]
        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public string mat_khau { get; set; }
    }
}
