using MediatR;
using pucminas.futebol.jogadores.domain.Entidades;

namespace pucminas.futebol.jogadores.infrastructure.CQRS.Commands
{
    public record CadastrarJogadorCommand(string nome, string sobrenome, string dataNascimento, string pais, string idTime) : IRequest<Jogador>;
}
