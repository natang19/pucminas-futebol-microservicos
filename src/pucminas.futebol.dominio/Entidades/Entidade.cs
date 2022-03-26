namespace pucminas.futebol.dominio.Entidades
{
    public abstract record Entidade
    {
        public Guid Id { get; init; }
        public DateTime DataCriacao { get; init; }

        public Entidade()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.UtcNow;
        }
    }
}
