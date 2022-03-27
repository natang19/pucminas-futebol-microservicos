namespace pucminas.futebol.core.Base
{
    public abstract record Entidade
    {
        public Guid Id { get; }
        public DateTime Criacao { get; }
        public DateTime UltimaAtualizacao { get; private set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
            Criacao = DateTime.UtcNow;
        }
    }
}
