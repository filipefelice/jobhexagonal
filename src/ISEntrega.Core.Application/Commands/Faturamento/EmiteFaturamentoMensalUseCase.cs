namespace ISEntrega.Core.Application.Commands.Faturamento
{
    using System.Threading.Tasks;    
    using ISEntrega.Core.Application.Repositories;
    using ISEntrega.Core.Domain.Faturamento;

    public class EmiteFaturamentoMensalUseCase : IEmiteFaturamentoMensalUseCase
    {
        private readonly IFaturamentoReadOnlyRepository _faturamentoReadOnlyRepository;
        private readonly IFaturamentoWriteOnlyRepository _faturamentoWriteOnlyRepository;
        private readonly IResultConverter resultConverter;


        public EmiteFaturamentoMensalUseCase(
            IFaturamentoReadOnlyRepository faturamentoReadOnlyRepository,
            IFaturamentoWriteOnlyRepository faturamentoWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this._faturamentoReadOnlyRepository = faturamentoReadOnlyRepository;
            this._faturamentoWriteOnlyRepository = faturamentoWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<ProcessaFaturamentoResult> Handle(ProcessaFaturamentoCommand command)
        {            
            var matrizes = await _faturamentoReadOnlyRepository.ListaMatrizes();

            foreach (var matriz in matrizes)
            {
                if (matriz.Efetiva())
                {
                    var pontos = await _faturamentoReadOnlyRepository.ListaPontosPorMatriz(matriz.Id);

                    foreach (var ponto in pontos)
                    {
                        if (ponto.Efetivo())
                        {
                            var faturamento = new Faturamento(matriz, ponto);

                            var rateio = faturamento.CalculaRateioPonto();

                            //if (ponto.InformacaoCobranca == null)
                            //    throw new PontoSemInformacaoCobrancaException($"Ponto {ponto.NomeFantasia} sem informação de cobrança");                            

                            //var informacaoCobranca = await _faturamentoReadOnlyRepository.ObtemInformacaoCobranca(ponto.InformacaoCobranca.Value);                            
                        }                        
                    }
                }
            }                        
            
            var result = resultConverter.Map<ProcessaFaturamentoResult>(new object { });

            return result;
        }
    }
}
