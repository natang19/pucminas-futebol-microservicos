using MediatR;
using pucminas.futebol.jogadores.domain.Entidades;

namespace pucminas.futebol.jogadores.infrastructure.CQRS.Queries
{
    public record ObterJogadorPorIdQuerie(string id) : IRequest<Jogador>;
}
