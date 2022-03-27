using System.Linq.Expressions;

namespace pucminas.futebol.core.Base
{
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : Entidade
    {
        Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate);
        Task<IEnumerable<TEntidade>> Obter();
        Task<TEntidade> Obter(Guid id);
        Task Adicionar(TEntidade entity);
        Task Atualizar(TEntidade entity);
        Task Remover(Guid id);
        Task<int> SaveChanges();
    }
}
