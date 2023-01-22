using Hangfire;
using Microsoft.AspNetCore.Mvc;
using HangfireExample.Models;

namespace HangfireExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        HangfireJob _hangfireJob = new();

        [HttpPost("Send")]
        public IActionResult Send(string userName)
        {
            var jobId = BackgroundJob.Enqueue(()=> _hangfireJob.SendWelcome(userName));
            return Ok($"Action = Send, Job Id = {jobId} COMPLETED");
        }

        [HttpPost("SendVersionOfHangFire")]
        public IActionResult SendVersionOfHangFire()
        {
            var jobId = BackgroundJob.Enqueue(() => _hangfireJob.SendVersionOfHangFire());
            return Ok($"Action = SendVersionOfHangFire, Job Id = {jobId} COMPLETED");
        }
    }
}
