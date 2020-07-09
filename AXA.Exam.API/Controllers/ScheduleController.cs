using AXA.Exam.API.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AXA.Exam.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase {
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(ILogger<ScheduleController> logger) {
            _logger = logger;
        }

        [HttpPost]
        public object Post([FromBody] ScheduleDal body) {
            if (HttpContext.Request.ContentType != "application/json") {
                return StatusCode(406, new ErrorResult() { Result = 406, ErrMessage = "ContentType should be 'application/json'" });
            }
            HttpContext.Request.Headers.TryGetValue("x-axa-api-key", out var apiKey);
            if (apiKey.Count == 0) {
                _logger.LogError("x-axa-api-key should be supplied");
                return StatusCode(406, new ErrorResult() { Result = 406, ErrMessage = "x-axa-api-key should be supplied" });
            }
            
            bool isValid = DateTime.TryParseExact(body.ProposedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d);
            if (!isValid) {
                return StatusCode(406, new ErrorResult() { Result = 406, ErrMessage = "Invalid Date Format. Proposed date should be in 'YYYY-MM-DD' format." });
            }

            var hrFormat = new Regex(@"(([2-9]|1[0-2])([AP][M]))");
            bool isValid2 = hrFormat.IsMatch(body.ProposedTime);
            if (!isValid2) {
                return StatusCode(406, new ErrorResult() { Result = 406, ErrMessage = "Invalid Time Format. Proposed time should be in 'Ha' format." });
            }


            return StatusCode(200, new SuccessResult() {
                Result = 200,
                Message = $"Proposed schedule submitted, kindly wait and check your email for futher notice. Thanks!"
            });
        }
    }
}
