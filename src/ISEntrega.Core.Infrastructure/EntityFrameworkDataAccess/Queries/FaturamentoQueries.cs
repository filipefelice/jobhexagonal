namespace ISEntrega.Core.Infrastructure.MongoDataAccess.Queries
{
    using System;
    using System.Threading.Tasks;
    using ISEntrega.Core.Application;
    using ISEntrega.Core.Application.Queries;
    using ISEntrega.Core.Application.Results;
    using ISEntrega.Core.Infrastructure.EntityFrameworkDataAccess;

    public class FaturamentoQueries : IFaturamentoQueries
    {
        private readonly Context context;
        private readonly IResultConverter mapper;

        public FaturamentoQueries(Context context, IResultConverter mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<FaturamentoResult> GetMatriz(Guid id)
        {
            var matriz = await context.Matrizes.FindAsync(id);

            if (matriz == null)
                return null;
            
            var faturamentoResult = this.mapper.Map<FaturamentoResult>(matriz);

            return faturamentoResult;
        }
    }
}
