using Microsoft.AspNetCore.Mvc;

namespace pucminas.futebol.times.api.Controllers
{
    [ApiController]
    [Route("api/times")]
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}