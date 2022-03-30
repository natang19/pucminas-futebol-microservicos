using Microsoft.Extensions.Options;
using pucminas.futebol.core.Base;
using pucminas.futebol.core.ModelOptions;
using pucminas.futebol.jogadores.domain.Entidades;

namespace pucminas.futebol.jogadores.infrastructure.Repositorio
{
    public class JogadorRepositorio : Repositorio<Jogador>, IJogadorRepositorio
    {
        public JogadorRepositorio(IOptions<MongoDbConnection> options) : base(options) { }
    }
}
