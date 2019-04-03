namespace ISEntrega.Core.Domain
{
    public interface IAggregateRoot : IEntity
    {
        bool IsValid();
    }
}