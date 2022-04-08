using MediatR;
using pucminas.futebol.jogadores.domain.DTOs;
using pucminas.futebol.jogadores.domain.Entidades;

namespace pucminas.futebol.jogadores.infrastructure.CQRS.Commands
{
    public record AtualizarJogadorCommand(JogadorUpdateDTO jogadorDTO) : IRequest<Jogador>;
}
