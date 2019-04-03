namespace ISEntrega.Core.Application
{
    public interface IResultConverter
    {
        T Map<T>(object source);
    }
}
