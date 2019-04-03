using System;

namespace ISEntrega.Core.Domain.Faturamento
{
    public class InformacaoCobranca: IAggregateRoot
    {
        public Guid Oid { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string NomeFantasia { get; set; }
        public Guid? Via { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public Guid? Pais { get; set; }
        public Guid? Estado { get; set; }
        public Guid? Cidade { get; set; }
        public string CEP { get; set; }
        public string Referencia { get; set; }
        public Guid? Matriz { get; set; }
        public int? EmpresaParaFaturar { get; set; }
        public Guid? PracaDePagamento { get; set; }
        public double? ValorTotalPontos { get; set; }
        public int? Codigo { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public bool? FaturarValorMatriz { get; set; }
        public Guid? EmpresaFaturamento { get; set; }
        public Guid? ContaCorrente { get; set; }
        public Guid? RotaEnvioFatura { get; set; }
        public double? PercentualMulta { get; set; }
        public double? PercentualJuros { get; set; }
        public Guid? BaseAtendimento { get; set; }
        public bool? EmissaoNotaFiscalEletronica { get; set; }
        public string Municipio { get; set; }
        public bool? FaturarValorFornecimentoMaoObra { get; set; }

        public Guid Id { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
