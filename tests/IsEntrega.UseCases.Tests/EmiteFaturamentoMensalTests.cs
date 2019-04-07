namespace IsEntrega.UseCases.Tests
{
    using ISEntrega.Core.Application;
    using ISEntrega.Core.Application.Commands.Faturamento;
    using ISEntrega.Core.Application.Repositories;
    using NSubstitute;
    using Xunit;

    public class EmiteFaturamentoMensalTests
    {
        public IFaturamentoReadOnlyRepository faturamentoReadOnlyRepository;
        public IFaturamentoWriteOnlyRepository faturamentoWriteOnlyRepository;
        public IResultConverter resultConverter;        

        public EmiteFaturamentoMensalTests()
        {
            faturamentoReadOnlyRepository = Substitute.For<IFaturamentoReadOnlyRepository>();
            faturamentoWriteOnlyRepository = Substitute.For<IFaturamentoWriteOnlyRepository>();
            resultConverter = Substitute.For<IResultConverter>();
        }

        [Fact]        
        public async void Verifica_Faturamento_Mensal_Ok()
        {
            var emiteFaturamentoMensalUseCase = new EmiteFaturamentoMensalUseCase(
                faturamentoReadOnlyRepository,
                faturamentoWriteOnlyRepository,
                resultConverter
            );            

            var result = await emiteFaturamentoMensalUseCase.Handle(new ProcessaFaturamentoCommand());            

            Assert.True(result.FaturamentoOk);            
        }
    }
}
