namespace pucminas.futebol.jogadores.domain.DTOs
{
    public record JogadorDTO
    {
        public string Nome { get; init; }
        public string Sobrenome { get; init; }
        public string DataNascimento { get; init; }
        public string Pais { get; init; }
        public string IdTime { get; init; }
    }
}
