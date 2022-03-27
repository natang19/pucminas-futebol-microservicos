namespace pucminas.futebol.core.DTOs
{
    public record TransferenciaDTO
    {
        public Guid Id { get; }
        public Guid IdJogador { get; }
        public Guid IdTimeOrigem { get; }
        public Guid IdTimeDestino { get; }
        public DateTime DataTransferencia { get; }
        public decimal Valor { get; }

        public TransferenciaDTO(Guid idJogador, Guid idTimeOrigem, Guid idTimeDestino, decimal valor)
        {
            Id = Guid.NewGuid();
            IdJogador = idJogador;
            IdTimeOrigem = idTimeOrigem;
            IdTimeDestino = idTimeDestino;
            DataTransferencia = DateTime.UtcNow;
            Valor = valor;
        }
    }
}
