using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.ViewModels
{
    public class AccountChange
    {
        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public string old_password { get; set; }
        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})",ErrorMessage = "Mật khẩu không đúng định dạng")]
        public string new_password { get; set; }
        [Required(ErrorMessage = "Không được để trống trường thông tin này ")]
        public string confirm_password { get; set; }
    }
}
