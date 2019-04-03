namespace ISEntrega.Core.Domain.Faturamento
{
    public class PontoSemInformacaoCobrancaException : DomainException
    {
        public PontoSemInformacaoCobrancaException(string message)
            : base(message)
        { }
    }
}
