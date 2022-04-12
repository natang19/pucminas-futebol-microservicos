using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using pucminas.futebol.core.ModelOptions;

namespace pucminas.futebol.core.Base
{
    public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade, new()
    {
        private readonly IMongoCollection<TEntidade> _collection;

        protected Repositorio(IOptions<MongoDbConnection> options)
        {
            var mongoDbClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoDbClient.GetDatabase(options.Value.DatabaseName);
            _collection = database.GetCollection<TEntidade>(options.Value.CollectionName);
        }

        public virtual async Task<IEnumerable<TEntidade>> Buscar(FilterDefinition<TEntidade> filtro)
        {
            var result = await _collection.FindAsync(filtro);

            return result.ToList();
        }

        public async Task<IEnumerable<TEntidade>> Obter()
        {
            var result = await _collection.FindAsync(_ => true);

            return result.ToList();
        }

        public async Task<TEntidade> Obter(string id)
        {
            var result = await _collection.FindAsync(entidade => entidade.Id == ObjectId.Parse(id));

            return result.FirstOrDefault();
        }

        public Task Adicionar(TEntidade entidade)
        {
            return _collection.InsertOneAsync(entidade);
        }

        public Task Atualizar(TEntidade entidade)
        {
            return _collection.ReplaceOneAsync(e => e.Id == entidade.Id, entidade, new ReplaceOptions { IsUpsert = true });
        }

        public Task Remover(string id)
        {
            return _collection.DeleteOneAsync(entidade => entidade.Id == ObjectId.Parse(id));
        }
    }
}
