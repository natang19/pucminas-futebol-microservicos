using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pucminas.futebol.core.Base
{
    public abstract record Entidade
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; }

        public DateTime Criacao { get; }

        public Entidade()
        {
            Id = ObjectId.GenerateNewId();
            Criacao = DateTime.UtcNow;
        }
    }
}
