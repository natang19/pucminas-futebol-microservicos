using MediatR;
using pucminas.futebol.jogadores.domain.Entidades;
using pucminas.futebol.jogadores.infrastructure.CQRS.Commands;
using pucminas.futebol.jogadores.infrastructure.Repositorio;

namespace pucminas.futebol.jogadores.business.Handlers
{
    public class CommandHandler : IRequestHandler<CadastrarJogadorCommand, Jogador>
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public CommandHandler(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }

        public Task<Jogador> Handle(CadastrarJogadorCommand request, CancellationToken cancellationToken)
        {
            var dataNascimento = Convert.ToDateTime(request.dataNascimento);

            var jogador = new Jogador() { Nome = request.nome, Sobrenome = request.sobrenome, Documento = request.documento, Nacionalidade = request.naconalidade, IdTime = request.idTime, DataNascimento = dataNascimento };

            _jogadorRepositorio.Adicionar(jogador);

            return Task.FromResult(jogador);
        }
    }
}
