using System;
using System.Collections.Generic;
using System.Linq;

namespace ISEntrega.Core.Domain.Faturamento
{
    public class Ponto : IAggregateRoot
    {
        public Guid Id { get; set; }
        public DateTime? DataInclusaoPonto { get; set; }
        public string Codigo { get; set; }
        public Guid? Matriz { get; set; }
        public bool? TipoMatriz { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string Identidade { get; set; }
        public string IdentidadeCliente { get; set; }
        public string InscricaoEstadual { get; set; }
        public int? Status { get; set; }
        public Guid? BaseAtendimento { get; set; }
        public Guid? Estabelecimento { get; set; }
        public Guid? InformacaoCobranca { get; set; }
        public Guid? Via { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public Guid? Pais { get; set; }
        public Guid? Estado { get; set; }
        public Guid? Cidade { get; set; }
        public string Referencia { get; set; }
        public double? ValorPonto { get; set; }
        public double? PesoContratado { get; set; }
        public double? ValorKGExcedente { get; set; }
        public DateTime? InicioAtividadePrevisto { get; set; }
        public DateTime? InicioAtividadeEfetivo { get; set; }
        public string Observacoes { get; set; }
        public bool? ValidarEntradaMesmoMalote { get; set; }
        public double? PesoContratadoMensal { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public string FrequenciaPonto { get; set; }
        public DateTime? DataInativacao { get; set; }
        public Guid? ColaboradorInativacao { get; set; }
        public int? FrequenciaPontoComercial { get; set; }
        public string InstrucoesComercial { get; set; }
        public int? CodigoExterno { get; set; }
        public byte[] Logo { get; set; }
        public bool? EnviarRoteirizacao { get; set; }
        public DateTime? DataHorarioAlteracao { get; set; }
        public Guid? ColaboradorAlteracao { get; set; }
        public int? OperacaoRoteirizacao { get; set; }
        public Guid? LeadTime { get; set; }
        public Guid? LeadTimeMatriz { get; set; }
        public string Particularidade { get; set; }
        public Guid? Rota { get; set; }
        public double? NovoValorPonto { get; set; }
        public DateTime? DataInicioNovoValorPonto { get; set; }
        public bool? ClienteIntegracao { get; set; }
        public DateTime? DataHora { get; set; }
        public string ObservacaoFinanceira { get; set; }
        public DateTime? DataHoraUltimaMovimentacao { get; set; }
        public bool? BloqueioOperacional { get; set; }
        public DateTime? DataHoraBloqueioOperacional { get; set; }
        public Guid? ColaboradorBloqueioOperacional { get; set; }
        public DateTime? PrimeiraDataMovimentacaoMalote { get; set; }
        public bool? PontoInativoAposFaturamento { get; set; }
        public string CodigoIdentificacaoCliente { get; set; }
        public Guid? FrequenciaComercialPonto { get; set; }
        public DateTime? DataFinalBloqueioOperacional { get; set; }
        public string FrequenciaVisores { get; set; }
        public double? ValorCobrancaKGExcedente { get; set; }
        public double? PesoMedio { get; set; }
        public int? CourrierPadrao { get; set; }
        public DateTime? DataReativacao { get; set; }
        public Guid? ColaboradorReativacao { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? AtendimentoFlexivel { get; set; }
        public string IDSF { get; set; }
        public string IDConta { get; set; }
        public bool? Sinc { get; set; }
        public int? TipoInterrupcao { get; set; }

        public int QuantidadeAtendimentosSemana
        {
            get
            {
                return this.FrequenciaPonto.Split(',').Count();
            }
        }

        public ICollection<string> AtendimentosSemana
        {
            get
            {
                return !string.IsNullOrEmpty(FrequenciaPonto) ? FrequenciaPonto.Split(',') : new string[0];
            }
        }

        public bool Efetivo()
        {
            if (this.InicioAtividadeEfetivo == null)
                return false;

            return DateTime.Now >= this.InicioAtividadeEfetivo.Value;
        }        

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
