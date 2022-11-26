using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: /<controller>/
        [Route("is_customer_before")]
        [HttpGet]
        public IActionResult IsCustomerBefore(string cmnd)
        {
            var is_khach = _customerService.kiemTraKhachCu(cmnd);
            return new JsonResult(is_khach);
        }
    }
}
