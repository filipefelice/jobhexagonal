namespace ISEntrega.Core.Application.Commands.Faturamento
{    
    using System.Threading.Tasks;

    public interface IEmiteFaturamentoMensalUseCase
    {
        Task<ProcessaFaturamentoResult> Handle(ProcessaFaturamentoCommand command);
    }
}
