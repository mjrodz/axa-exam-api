using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AXA.Exam.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public object Get() {
            return new { value = "Welcome" };
        }
    }
}
