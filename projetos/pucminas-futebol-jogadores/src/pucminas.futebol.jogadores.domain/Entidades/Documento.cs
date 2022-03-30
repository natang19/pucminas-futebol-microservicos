using pucminas.futebol.jogadores.domain.Enuns;

namespace pucminas.futebol.jogadores.domain.Entidades
{
    public record Documento
    {
        public TipoDocumento TipoDocumento { get; set; }
        public string CodigoDocumento { get; init; }

        public bool DocumentoValido()
        {
            return true;
        }
    }
}
