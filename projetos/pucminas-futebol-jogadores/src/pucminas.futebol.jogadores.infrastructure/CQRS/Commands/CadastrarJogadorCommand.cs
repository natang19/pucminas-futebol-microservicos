using MediatR;
using pucminas.futebol.jogadores.domain.Entidades;

namespace pucminas.futebol.jogadores.infrastructure.CQRS.Commands
{
    public record CadastrarJogadorCommand(string nome, string sobrenome, string dataNascimento, Documento documento, Nacionalidade naconalidade, string idTime) : IRequest<Jogador>;
}
