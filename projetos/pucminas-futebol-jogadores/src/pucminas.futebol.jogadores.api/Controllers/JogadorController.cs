using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using pucminas.futebol.jogadores.domain.DTOs;
using pucminas.futebol.jogadores.infrastructure.CQRS.Commands;
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
        private readonly IMapper _mapper;

        public JogadorController(ILogger<JogadorController> logger, ISender mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(typeof(IEnumerable<JogadorResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<JogadorResponseDTO>>> Get()
        {
            var querieResult = await _mediator.Send(new ObterJogadoresQuerie());

            if (!querieResult.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<JogadorResponseDTO>>(querieResult));
        }

        [HttpGet("{id}")]
        [EnableQuery]
        [ProducesResponseType(typeof(JogadorResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JogadorResponseDTO>> GetById([FromRoute]string id)
        {
            var querieResult = await _mediator.Send(new ObterJogadorPorIdQuerie(id));

            if (querieResult is null)
            {
                return NotFound("Jogador não encontrado!");
            }

            return Ok(_mapper.Map<JogadorResponseDTO>(querieResult));
        }

        [HttpPost]
        [ProducesResponseType(typeof(JogadorResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] JogadorDTO jogadorDTO)
        {
            var commandResult = await _mediator.Send(new CadastrarJogadorCommand(jogadorDTO.Nome, jogadorDTO.Sobrenome, jogadorDTO.DataNascimento, jogadorDTO.Pais, jogadorDTO.IdTime));

            var jogadorResponseDTO = _mapper.Map<JogadorResponseDTO>(commandResult);

            return CreatedAtAction(nameof(GetById), new { Id = jogadorResponseDTO.Id}, jogadorResponseDTO);
        }

        [HttpPut]
        [ProducesResponseType(typeof(JogadorResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JogadorResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] JogadorUpdateDTO jogadorDTO)
        {
            JogadorResponseDTO jogadorResponseDTO;

            if (string.IsNullOrEmpty(jogadorDTO.Id))
            {
                var criacaoCommandResult = await _mediator.Send(new CadastrarJogadorCommand(jogadorDTO.Nome, jogadorDTO.Sobrenome, jogadorDTO.DataNascimento, jogadorDTO.Pais, jogadorDTO.IdTime));

                jogadorResponseDTO = _mapper.Map<JogadorResponseDTO>(criacaoCommandResult);

                return CreatedAtAction(nameof(GetById), new { Id = jogadorResponseDTO.Id }, jogadorResponseDTO);
            }

            var atualizacaoCommandResult = await _mediator.Send(new AtualizarJogadorCommand(jogadorDTO));
            jogadorResponseDTO = _mapper.Map<JogadorResponseDTO>(atualizacaoCommandResult);

            return Ok(jogadorResponseDTO);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _mediator.Send(new ExcluirJogadorCommand(id));

            return NoContent();
        }
    }
}