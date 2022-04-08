using MediatR;

namespace pucminas.futebol.jogadores.infrastructure.CQRS.Commands
{
    public record ExcluirJogadorCommand(string id) : IRequest;
}
