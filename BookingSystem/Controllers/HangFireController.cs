using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangFireController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public HangFireController(ILogger<HangFireController> logger, IBackgroundJobClient backgroundJobClient)
        {
            _logger = logger;
            _backgroundJobClient = backgroundJobClient;
        }
        [HttpGet]
        public IActionResult GetHangFire()
        {

            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Expired"), TimeSpan.FromDays(30));
            return Ok();
        }
    }
}
