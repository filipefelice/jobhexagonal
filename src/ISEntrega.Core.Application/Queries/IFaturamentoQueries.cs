namespace ISEntrega.Core.Application.Queries
{
    using ISEntrega.Core.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface IFaturamentoQueries
    {
        Task<FaturamentoResult> GetMatriz(Guid id);
    }
}
