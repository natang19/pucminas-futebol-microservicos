using MongoDB.Bson.Serialization.Attributes;

namespace pucminas.futebol.core.Base
{
    public abstract record Entidade
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; }

        public DateTime Criacao { get; }

        public Entidade()
        {
            Criacao = DateTime.UtcNow;
        }
    }
}
