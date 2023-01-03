using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.HealthCheck
{
    [ApiController]
    [Route("_healthcheck")]
    [AllowAnonymous]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        [Route("status")]
        public ActionResult<string> Status()
        {
            return Ok("health");
        }
    }
}