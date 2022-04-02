using MediatR;
using Microsoft.AspNetCore.Mvc;
using pucminas.futebol.jogadores.domain.Entidades;
using pucminas.futebol.jogadores.infrastructure.CQRS.Queries;

namespace pucminas.futebol.jogadores.api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("jogadores")]
    public class JogadorController : ControllerBase
    {
        private readonly ILogger<JogadorController> _logger;
        private readonly ISender _mediator;

        public JogadorController(ILogger<JogadorController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogador>>> Get()
        {
            var querieResult = await _mediator.Send(new ObterJogadoresQuerie());

            if (!querieResult.Any())
            {
                return NoContent();
            }

            return Ok(querieResult);
        }
    }
}