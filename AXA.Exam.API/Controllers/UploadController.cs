using AXA.Exam.API.Classes;
using AXA.Exam.API.DBContexts;
using AXA.Exam.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AXA.Exam.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase {
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger) {
            _logger = logger;
        }

        [HttpPost]
        public object Post([FromBody] UploadDal body) {
            if (HttpContext.Request.ContentType != "application/json") {
                return StatusCode(406, new ErrorResult() { Result = 406, ErrMessage = "ContentType should be 'application/json'" });
            }
            HttpContext.Request.Headers.TryGetValue("x-axa-api-key", out var apiKey);
            if (apiKey.Count == 0) {
                return StatusCode(406, new ErrorResult() { Result = 406, ErrMessage = "x-axa-api-key should be supplied" });
            }


            return StatusCode(200, new SuccessResult() {
                Result = 200,
                Message = $"Upload successful"
            });
        }
    }
}
