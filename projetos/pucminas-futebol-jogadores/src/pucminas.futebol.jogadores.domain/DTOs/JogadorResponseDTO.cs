namespace pucminas.futebol.jogadores.domain.DTOs
{
    public record JogadorResponseDTO : JogadorDTO
    {
        public string Id { get; set; }
        public string DataCadastro { get; set; }
        public int Idade => CalcularIdade();

        private int CalcularIdade()
        {
            var dataNascimento = DateTime.Parse(this.DataNascimento);
            var dataAtual = DateTime.Now;
            var idade = dataAtual.Year - dataNascimento.Year;

            if ((dataAtual.Month == dataNascimento.Month) && (dataAtual.Day == dataNascimento.Day))
            {
                return idade;
            }

            return idade - 1;
        }
    }
}
