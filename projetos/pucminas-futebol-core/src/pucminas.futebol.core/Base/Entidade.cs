using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pucminas.futebol.core.Base
{
    public abstract record Entidade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; init; }

        public DateTime Criacao { get; init; }

        protected Entidade()
        {
            Id = ObjectId.GenerateNewId();
            Criacao = DateTime.UtcNow;
        }
    }
}
