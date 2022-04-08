using pucminas.futebol.core.Base;

namespace pucminas.futebol.jogadores.domain.Entidades
{
    public record Jogador : Entidade
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Pais { get; set; }
        public string IdTime { get; set; }
    }
}
