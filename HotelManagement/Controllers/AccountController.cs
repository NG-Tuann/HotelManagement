﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        // GET: /<controller>/
        [Route("login")]
        [Route("")]
        public IActionResult Login()
        {
            return View("login");
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View("register");
        }
    }
}