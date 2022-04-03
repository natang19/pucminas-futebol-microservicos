using pucminas.futebol.jogadores.domain.Entidades;

namespace pucminas.futebol.jogadores.domain.DTOs
{
    public record JogadorDTO
    {
        public string Nome { get; init; }
        public string Sobrenome { get; init; }
        public string DataNascimento { get; init; }
        public Documento Documento { get; init; }
        public Nacionalidade Nacionalidade { get; init; }
        public string IdTime { get; init; }
    }
}
