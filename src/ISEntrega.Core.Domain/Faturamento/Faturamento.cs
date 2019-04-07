namespace ISEntrega.Core.Domain.Faturamento
{
    using ISEntrega.Core.Domain.ValueObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Faturamento : Entity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        private readonly Matriz matriz;
        private readonly Ponto ponto;
        private decimal ValorMatriz
        {
            get { return matriz.ValorMatriz ?? 0; }
        }
        private double ValorPonto
        {
            get { return ponto.ValorPonto ?? 0; }
        }       

        public Faturamento(Matriz matriz, Ponto ponto)
        {
            this.matriz = matriz;
            this.ponto = ponto;
        }       

        public double CalculaRateioPonto()
        {
            if (ValorPonto == 0)
                return 0;

            var mesPassado = DateTime.Now.AddMonths(-1);
            var inicioRateio = new DateTime(mesPassado.Year, mesPassado.Month, 1);
            var fimRateio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);

            var dataRateio = inicioRateio;

            var rateio = 0d;

            while (dataRateio < fimRateio)
            {
                // Verificar se não é feriado.

                switch (dataRateio.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        {
                            if (TemAtendimento(ponto.AtendimentosSemana, "Sexta"))
                                rateio += ValorPonto;
                            break;
                        }
                    case DayOfWeek.Monday:
                        {
                            if (TemAtendimento(ponto.AtendimentosSemana, "Segunda"))
                                rateio += ValorPonto;
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            if (TemAtendimento(ponto.AtendimentosSemana, "Sábado"))
                                rateio += ValorPonto;
                            break;
                        }
                    case DayOfWeek.Sunday:
                        {
                            if (TemAtendimento(ponto.AtendimentosSemana, "Domingo"))
                                rateio += ValorPonto;
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            if (TemAtendimento(ponto.AtendimentosSemana, "Quinta"))
                                rateio += ValorPonto;
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            if (TemAtendimento(ponto.AtendimentosSemana, "Terça"))
                                rateio += ValorPonto;
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            if (TemAtendimento(ponto.AtendimentosSemana, "Quarta"))
                                rateio += ValorPonto;
                            break;
                        }
                }

                dataRateio = dataRateio.AddDays(1);
            }

            return rateio;
        }

        public decimal CalculaRateioMatriz()
        {
            if (ValorMatriz == null)
                return 0;

            var mesPassado = DateTime.Now.AddMonths(-1);
            var inicioRateio = new DateTime(mesPassado.Year, mesPassado.Month, 1);
            var fimRateio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);

            var dataRateio = inicioRateio;

            var rateio = 0M;

            while (dataRateio < fimRateio)
            {
                // Verificar se não é feriado.

                switch (dataRateio.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        {
                            if (TemAtendimento(matriz.AtendimentosSemana, "Sexta"))
                                rateio += ValorMatriz;
                            break;
                        }
                    case DayOfWeek.Monday:
                        {
                            if (TemAtendimento(matriz.AtendimentosSemana, "Segunda"))
                                rateio += ValorMatriz;
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            if (TemAtendimento(matriz.AtendimentosSemana, "Sábado"))
                                rateio += ValorMatriz;
                            break;
                        }
                    case DayOfWeek.Sunday:
                        {
                            if (TemAtendimento(matriz.AtendimentosSemana, "Domingo"))
                                rateio += ValorMatriz;
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            if (TemAtendimento(matriz.AtendimentosSemana, "Quinta"))
                                rateio += ValorMatriz;
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            if (TemAtendimento(matriz.AtendimentosSemana, "Terça"))                                
                                rateio += ValorMatriz;
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            if (TemAtendimento(matriz.AtendimentosSemana, "Quarta"))
                                rateio += ValorMatriz;
                            break;
                        }
                }

                dataRateio = dataRateio.AddDays(1);
            }

            return rateio;
        }

        public bool TemAtendimento(ICollection<string> atendimentosSemana, string diaDaSemana)
        {
            return atendimentosSemana.Any(dia => dia.Trim() == diaDaSemana);
        }

        public bool IsValid()
        {
            // Implementar fluent validation
            throw new NotImplementedException();
        }
    }
}
