using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("Error")]
    public class ErrorController : Controller
    {
        // GET: /<controller>/
        [Route("404")]
        public IActionResult Error404()
        {
            return View("Error404");
        }

        [Route("500")]
        public IActionResult Error500()
        {
            return View("Error500");
        }

        [Route("403")]
        public IActionResult Error403()
        {
            return View("Error403");
        }
    }
}
