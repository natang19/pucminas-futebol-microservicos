using pucminas.futebol.dominio.Enuns;

namespace pucminas.futebol.dominio.Entidades
{
    public record Jogador : Entidade
    {
        public string Nome { get; init; }

        public string Sobrenome { get; init; }
        
        public DateTime DataNascimento { get; init; }
        
        public TipoDocumento TipoDocumento { get; init; }
        
        public string CodigoDocumento { get; set; }
        
        public int Idade => Convert.ToInt32(DateTime.UtcNow - DataNascimento);
        
        public Guid IdTime { get; init; }
    }
}
