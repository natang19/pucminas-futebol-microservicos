using pucminas.futebol.core.Base;

namespace pucminas.futebol.jogadores.domain.Entidades
{
    public record Jogador : Entidade
    {
        public string Nome { get; init; }
        public string Sobrenome { get; init; }
        public DateTime DataNascimento { get; init; }
        public Documento Documento { get; init; }
        public Nacionalidade Nacionalidade { get; init; }
        public string IdTime { get; init; }
    }
}
