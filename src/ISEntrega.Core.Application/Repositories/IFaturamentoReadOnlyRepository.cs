namespace ISEntrega.Core.Application.Repositories
{
    using ISEntrega.Core.Domain.Faturamento;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFaturamentoReadOnlyRepository
    {
        Task<List<Matriz>> ListaMatrizes();

        Task<List<Ponto>> ListaPontosPorMatriz(Guid matriz);

        Task<InformacaoCobranca> ObtemInformacaoCobranca(Guid id);

        Task<EmpresaFaturamento> ObtemEmpresaFaturamento(Guid id);
        
    }
}
