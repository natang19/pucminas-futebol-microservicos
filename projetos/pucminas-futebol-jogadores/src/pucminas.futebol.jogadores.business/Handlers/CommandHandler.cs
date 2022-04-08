using MediatR;
using MongoDB.Driver;
using pucminas.futebol.jogadores.domain.Entidades;
using pucminas.futebol.jogadores.domain.Exceptions;
using pucminas.futebol.jogadores.infrastructure.CQRS.Commands;
using pucminas.futebol.jogadores.infrastructure.Repositorio;

namespace pucminas.futebol.jogadores.business.Handlers
{
    public class CommandHandler :
        IRequestHandler<CadastrarJogadorCommand, Jogador>,
        IRequestHandler<AtualizarJogadorCommand, Jogador>,
        IRequestHandler<ExcluirJogadorCommand>
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public CommandHandler(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }

        public async Task<Jogador> Handle(CadastrarJogadorCommand request, CancellationToken cancellationToken)
        {
            //Verificar se existe jogador com o mesmo nome e sobrenome
            var builder = Builders<Jogador>.Filter;
            var filtro = builder.Eq(j => j.Nome, request.nome) & builder.Eq(j => j.Sobrenome, request.sobrenome);
            var resultadoBusca = await _jogadorRepositorio.Buscar(filtro);

            if (resultadoBusca.Any())
            {
                throw new BusinessException("Jogador já possui cadastro no sistema!");
            }

            var dataNascimento = Convert.ToDateTime(request.dataNascimento);

            var jogador = new Jogador() { Nome = request.nome, Sobrenome = request.sobrenome, Pais = request.pais, IdTime = request.idTime, DataNascimento = dataNascimento };

            await _jogadorRepositorio.Adicionar(jogador);

            return jogador;
        }

        public async Task<Jogador> Handle(AtualizarJogadorCommand request, CancellationToken cancellationToken)
        {
            var jogador = await _jogadorRepositorio.Obter(request.jogadorDTO.Id);

            if (jogador is null)
            {
                throw new BusinessException("Erro ao atualizar as informações do jogador");
            }

            jogador.Nome = request.jogadorDTO.Nome;
            jogador.Sobrenome = request.jogadorDTO.Sobrenome;
            jogador.DataNascimento = DateTime.Parse(request.jogadorDTO.DataNascimento);
            jogador.Pais = request.jogadorDTO.Pais;
            jogador.IdTime = request.jogadorDTO.IdTime;

            await _jogadorRepositorio.Atualizar(jogador);

            return jogador;
        }

        public Task<Unit> Handle(ExcluirJogadorCommand request, CancellationToken cancellationToken)
        {
            _jogadorRepositorio.Remover(request.id);
            return Task.FromResult(new Unit());
        }
    }
}
