using MongoDB.Driver;

namespace pucminas.futebol.core.Base
{
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : Entidade
    {
        Task<IEnumerable<TEntidade>> Buscar(FilterDefinition<TEntidade> filtro);
        Task<IEnumerable<TEntidade>> Obter();
        Task<TEntidade> Obter(string id);
        Task Adicionar(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task Remover(string id);
    }
}
