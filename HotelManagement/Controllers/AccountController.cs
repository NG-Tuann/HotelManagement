using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using DemoSession15.Helpers;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private IConfiguration _configuration;
        private IBaseRepository<TaiKhoan> _taiKhoanRepo;

        public AccountController(IBaseRepository<TaiKhoan> taiKhoanRepo, IConfiguration configuration)
        {
            _taiKhoanRepo = taiKhoanRepo;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.taiKhoans = _taiKhoanRepo.GetAll().ToList();
            return View("index");
        }

        // GET: /<controller>/
        [Route("~/")]
        [Route("login")]
        public IActionResult Login(String message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Debug.WriteLine("Message: " + message);
                ViewBag.message = message;
            }

            return View("login", new Account());
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Account account)
        {
            if(ModelState.IsValid)
            {
                var validUsername = _taiKhoanRepo.GetAll().ToList().SingleOrDefault(i => i.TaiKhoan1 == account.tai_khoan);
                if(validUsername !=null)
                {
                    bool isValidAccount = BCrypt.Net.BCrypt.Verify(account.mat_khau, validUsername.MatKhau);
                    if(isValidAccount)
                    {
                        HttpContext.Session.SetString("account_info", JsonConvert.SerializeObject(account));
                        return RedirectToAction("index", "house", new { message = "login_success" });
                    }
                    else
                    {
                        return RedirectToAction("login", new { message = "wrong_password" });
                    }
                }
                else
                {
                    return RedirectToAction("login", new { message = "username_not_exists" });
                }
            }
            else
            {
                return View("login");
            }
        }

        [Route("register")]
        public IActionResult Register(String message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Debug.WriteLine("Message: " + message);
                ViewBag.message = message;
            }
            var taiKhoan = new TaiKhoan();
            taiKhoan.NgaySinh = DateTime.ParseExact("01/01/2022", "dd/MM/yyyy",
                                         System.Globalization.CultureInfo.InvariantCulture);
            return View("register", taiKhoan);
        }

        [HttpGet]
        [Route("forgot_password")]
        public IActionResult ForgotPassword()
        {
            return View("forgotpassword", new AccountVerify());
        }

        [HttpPost]
        [Route("forgot_password")]
        public IActionResult ForgotPassword(AccountVerify accountVerify)
        {
            if(ModelState.IsValid)
            {
                if (!accountVerify.tai_khoan.Contains("@gmail.com"))
                {
                    ModelState.AddModelError("tai_khoan", "Không đúng định dạng email");
                    return View("forgotpassword", new AccountVerify());
                }
                else
                {
                    var isUserAccount = _taiKhoanRepo.GetAll().ToList().SingleOrDefault(i => i.TaiKhoan1 == accountVerify.tai_khoan);
                    if(isUserAccount == null)
                    {
                        ModelState.AddModelError("tai_khoan", "Tài khoản email này chưa được đăng ký");
                        return View("forgotpassword", new AccountVerify());
                    }
                    else
                    {
                        Random rnd = new Random();

                        // Gui mail random password cho nhan vien
                        var randomPassword = rnd.Next(100000, 999999);

                        string passwordHash = BCrypt.Net.BCrypt.HashPassword(randomPassword.ToString());

                        // Cap nhat lai mat khau moi
                        isUserAccount.MatKhau = passwordHash;

                        _taiKhoanRepo.Update(isUserAccount);
                        _taiKhoanRepo.Save();

                        // Gui mail cap lai mat khau moi

                        var mailHelper = new MailHelper(_configuration);
                        string subject = "Mail gửi với mục đích Cấp lại mật khẩu mới";
                        string content = "Sau khi nhận mật khẩu hãy đăng nhập và thay đổi mật khẩu. Mật khẩu của bạn là: " + randomPassword;
                        if (mailHelper.Send("tuan.ng400@aptechlearning.edu.vn", isUserAccount.TaiKhoan1, subject, content))
                        {
                            Debug.WriteLine("Send mail success");
                        }
                        else
                        {
                            Debug.WriteLine("Send mail fail");
                        }
                        return RedirectToAction("login", new { message = "new_password_send_to_mail" });
                    }
                }
            }
            else
            {
                return View("forgotpassword", new AccountVerify());
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(TaiKhoan taiKhoan)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    taiKhoan.Matk = "NV" + PrimaryKeyHelper.RandomString(3);
                    // Cap mat khau cho nhan vien
                    Random rnd = new Random();

                    // Gui mail random password cho nhan vien
                    var randomPassword = rnd.Next(100000, 999999);

                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(randomPassword.ToString());
                    taiKhoan.MatKhau = passwordHash;

                    var mailHelper = new MailHelper(_configuration);
                    string subject = "Mail gửi với mục đích kích hoạt tài khoản và thông tin về mật khẩu";
                    string content = "Sau khi nhận mật khẩu hãy đăng nhập và thay đổi mật khẩu. Mật khẩu của bạn là: " + randomPassword;
                    if (mailHelper.Send("tuan.ng400@aptechlearning.edu.vn", taiKhoan.TaiKhoan1, subject, content))
                    {
                        Debug.WriteLine("Send mail success");
                    }
                    else
                    {
                        Debug.WriteLine("Send mail fail");
                    }

                    _taiKhoanRepo.Insert(taiKhoan);
                    _taiKhoanRepo.Save();
                    return RedirectToAction("register", new { message = "register_success" });
                } catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return RedirectToAction("register", new { message = "register_fail" });
                }

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("account_info");
            return RedirectToAction("login");
        }

        [HttpGet]
        [Route("change_password")]
        public IActionResult ChangePassword()
        {
            return View("ChangePassword", new AccountChange());
        }

        [HttpPost]
        [Route("change_password")]
        public IActionResult ChangePassword(AccountChange account)
        {
            if(ModelState.IsValid)
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account_info"));
                var taiKhoan = _taiKhoanRepo.GetAll().ToList().SingleOrDefault(i => i.TaiKhoan1 == acc.tai_khoan);
                bool isValidAccount = BCrypt.Net.BCrypt.Verify(account.old_password, taiKhoan.MatKhau);
                if(isValidAccount)
                {
                    if(account.confirm_password == account.new_password)
                    {
                        // Thuc hien cap nhat mau khau
                        taiKhoan.MatKhau = BCrypt.Net.BCrypt.HashPassword(account.new_password.ToString());

                        _taiKhoanRepo.Update(taiKhoan);
                        _taiKhoanRepo.Save();
                        return RedirectToAction("index", "room", new { message = "change_password_success" });
                    }
                    else
                    {
                        ModelState.AddModelError("confirm_password", "Không khớp mật khẩu mới");
                        return View("ChangePassword", new AccountChange());
                    }
                }
                else
                {
                    ModelState.AddModelError("old_password", "Sai mật khẩu");
                    return View("ChangePassword", new AccountChange());
                }
            }
            else
            {
                return View("ChangePassword", new AccountChange());
            }
        }
    }
}
