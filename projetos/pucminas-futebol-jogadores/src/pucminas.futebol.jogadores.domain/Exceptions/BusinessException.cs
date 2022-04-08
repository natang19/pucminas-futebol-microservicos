namespace pucminas.futebol.jogadores.domain.Exceptions
{
    public class BusinessException : Exception 
    {
        public BusinessException(string message) : base(message) { }
    }
}
