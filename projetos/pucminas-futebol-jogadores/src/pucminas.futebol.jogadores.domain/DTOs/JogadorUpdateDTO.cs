namespace pucminas.futebol.jogadores.domain.DTOs
{
    public record JogadorUpdateDTO : JogadorDTO
    {
        public string Id { get; set; }
    }
}
