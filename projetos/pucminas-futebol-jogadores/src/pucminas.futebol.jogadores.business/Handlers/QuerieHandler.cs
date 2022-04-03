using MediatR;
using pucminas.futebol.jogadores.domain.Entidades;
using pucminas.futebol.jogadores.infrastructure.CQRS.Queries;
using pucminas.futebol.jogadores.infrastructure.Repositorio;

namespace pucminas.futebol.jogadores.business.Handlers
{
    public class QuerieHandler : IRequestHandler<ObterJogadoresQuerie, IEnumerable<Jogador>>
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public QuerieHandler(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }

        public Task<IEnumerable<Jogador>> Handle(ObterJogadoresQuerie request, CancellationToken cancellationToken)
        {
            return _jogadorRepositorio.Obter();
        }
    }
}
