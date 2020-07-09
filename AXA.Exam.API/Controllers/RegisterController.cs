using AXA.Exam.API.Classes;
using AXA.Exam.API.DBContexts;
using AXA.Exam.API.Helper;
using AXA.Exam.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AXA.Exam.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger) {
            _logger = logger;
        }

        [HttpPost]
        public object Post([FromBody] RegisterDal body) {
            if (HttpContext.Request.ContentType != "application/json") {
                return StatusCode(406, new ErrorResult() { Result = 406, ErrMessage = "ContentType should be 'application/json'" });
            }

            var apiKey = StringHelper.RandomString(16);

            using (var context = new AXAExamSampleDBContext()) {
                var existApplicant = context.Applicants.Where(o => o.Email == body.Email).FirstOrDefault();
                if (existApplicant != null) {
                    if (existApplicant.Id != 0) {
                        return StatusCode(200, new SuccessResult() {
                            Result = 200,
                            Message = $"Thank you for registering! Your x-axa-api-key is: {existApplicant.XaxaApiKey}"
                        });
                    }
                }

                var applicant = new Applicants() {
                    Name = body.Name,
                    Email = body.Email,
                    Mobile = body.Mobile,
                    PositionApplied = body.PositionApplied,
                    Source = body.Source,
                    XaxaApiKey = apiKey
                };

                context.Applicants.Add(applicant);
                context.SaveChanges();
            }

            return StatusCode(200, new SuccessResult() {
                Result = 200,
                Message = $"Thank you for registering! Your x-axa-api-key is: {apiKey}"
            });
        }
    }
}
