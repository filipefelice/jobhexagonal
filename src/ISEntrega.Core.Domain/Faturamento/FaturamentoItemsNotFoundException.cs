namespace ISEntrega.Core.Domain.Faturamento
{
    public class FaturamentoItemsNotFoundException : DomainException
    {
        public FaturamentoItemsNotFoundException(string message)
            : base(message)
        { }
    }
}
