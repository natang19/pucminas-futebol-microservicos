using System.Linq.Expressions;

namespace pucminas.futebol.core.Base
{
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : Entidade
    {
        Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> filtro);
        Task<IEnumerable<TEntidade>> Obter();
        Task<TEntidade> Obter(string id);
        Task Adicionar(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task Remover(string id);
    }
}
