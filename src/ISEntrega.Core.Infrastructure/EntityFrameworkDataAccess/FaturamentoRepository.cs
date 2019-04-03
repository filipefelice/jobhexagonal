namespace ISEntrega.Core.Infrastructure.EntityFrameworkDataAccess
{
    using ISEntrega.Core.Application.Repositories;   
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using ISEntrega.Core.EntityFrameworkDataAccess.Entities;
    using Domain = ISEntrega.Core.Domain.Faturamento;
    using System.Linq;
    using ISEntrega.Core.Infrastructure.Mappings;

    public class FaturamentoRepository : IFaturamentoReadOnlyRepository, IFaturamentoWriteOnlyRepository
    {
        private readonly Context context;
        private readonly ResultConverter resultConverter;

        public FaturamentoRepository(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            resultConverter = new ResultConverter();
        }

        public async Task<List<Domain.Matriz>> ListaMatrizes()
        {
            var matrizes = await context.Matrizes.ToListAsync();
            
            return resultConverter.Map<List<Domain.Matriz>>(matrizes);
        }

        public async Task<List<Domain.Ponto>> ListaPontosPorMatriz(Guid matriz)
        {
            var pontos = await context.Pontos.Where(o => o.Matriz == matriz).ToListAsync();

            return resultConverter.Map<List<Domain.Ponto>>(pontos);
        }

        public async Task<Domain.InformacaoCobranca> ObtemInformacaoCobranca(Guid id)
        {
            var informacaoCobranca = await context.InformacoesCobranca.FirstOrDefaultAsync(o => o.Oid == id);

            return resultConverter.Map<Domain.InformacaoCobranca>(informacaoCobranca);
        }

        public async Task<Domain.EmpresaFaturamento> ObtemEmpresaFaturamento(Guid id)
        {
            var empresaFaturamento = await context.EmpresasFaturamento.FirstOrDefaultAsync(o => o.Oid == id);

            return resultConverter.Map<Domain.EmpresaFaturamento>(empresaFaturamento);
        }
    }
}
