using Microsoft.AspNetCore.Mvc;

namespace pucminas.futebol.jogadores.api.Controllers
{
    [ApiController]
    [Route("api/jogadores")]
    public class JogadorController : ControllerBase
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
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