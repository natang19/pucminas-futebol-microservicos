using System.Linq.Expressions;

namespace pucminas.futebol.core.Base
{
    public abstract class Repository<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade, new()
    {
        public Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntidade>> Obter()
        {
            throw new NotImplementedException();
        }

        public Task<TEntidade> Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Adicionar(TEntidade entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TEntidade entity)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
