using ISEntrega.Core.Domain.Faturamento;
using Xunit;

namespace IsEntrega.Domain.Tests
{
    public class FaturamentoTests
    {
        [Fact]
        public void Calcula_Rateio_Matriz()
        {
            var matriz = new Matriz();
            var ponto = new Ponto();

            var faturamento = new Faturamento(matriz, ponto);
            
            // Assert
            Assert.True(faturamento.CalculaRateioMatriz() > 0);
        }

        [Fact]
        public void Calcula_Rateio_Ponto()
        {
            var matriz = new Matriz();
            var ponto = new Ponto();

            var faturamento = new Faturamento(matriz, ponto);

            // Assert
            Assert.True(faturamento.CalculaRateioPonto() > 0);
        }       
    }
}
