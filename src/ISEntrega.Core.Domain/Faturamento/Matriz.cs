﻿using System;
using System.Collections.Generic;

namespace ISEntrega.Core.Domain.Faturamento
{    
    public class Matriz: IAggregateRoot
    {        
        public Guid? GrupoEmpresarial { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string InscricaoEstadual { get; set; }
        public Guid? BaseAtendimento { get; set; }
        public Guid? Estabelecimento { get; set; }
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
        public DateTime? DataContrato { get; set; }
        public DateTime? DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string NumeroCotrato { get; set; }
        public Guid? IndiceReajuste { get; set; }
        public int? MaloteNegociado { get; set; }
        public string DetalhesOperacao { get; set; }
        public int? DiaEmissaoFatura { get; set; }
        public int? DiaVencimentoFatura { get; set; }
        public int? DiaEmissaoFatura2 { get; set; }
        public int? DiaVencimentoFatura2 { get; set; }
        public bool? FaturaMesmoMesGeracaoFatura { get; set; }
        public byte[] Logo { get; set; }
        public string Codigo { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public decimal? ValorMatriz { get; set; }
        public int? Situacao { get; set; }
        public DateTime? DataInativacao { get; set; }
        public Guid? ColaboradorInativacao { get; set; }
        public int? CodigoExterno { get; set; }
        public bool? EnviarRoteirizacao { get; set; }
        public DateTime? DataHorarioAlteracao { get; set; }
        public Guid? ColaboradorAlteracao { get; set; }
        public int? OperacaoRoteirizacao { get; set; }
        public string FrequenciaMatriz { get; set; }
        public bool? _FaturaMesmoMesGeracaoFaturaExcedente { get; set; }
        public bool? FaturaMesmoMesGeracaoFaturaExcedente { get; set; }
        public double? Comissao { get; set; }
        public Guid? Vendedor { get; set; }
        public string Particularidade { get; set; }
        public bool? ClienteIntegracao { get; set; }
        public DateTime? DataHora { get; set; }
        public Guid? UltimoContato { get; set; }
        public int? QuantidadeDiasSemContato { get; set; }
        public string StatusComercial { get; set; }
        public string StatusFinanceiro { get; set; }
        public Guid? Segmento { get; set; }
        public Guid? RamoAtividade { get; set; }
        public string Regiao { get; set; }
        public string MotivoInativacao { get; set; }
        public bool? BloqueioOperacional { get; set; }
        public DateTime? DataHoraBloqueioOperacional { get; set; }
        public Guid? ColaboradorBloqueioOperacional { get; set; }
        public bool? Reajustado { get; set; }
        public DateTime? DataProximoReajuste { get; set; }
        public DateTime? PrimeiraDataInicioAtividadeEfetivo { get; set; }
        public double? INSS { get; set; }
        public double? ISS { get; set; }
        public Guid? UltimoRegistroAgenda { get; set; }
        public bool? ColetaReduzida { get; set; }
        public bool? EntregaReduzida { get; set; }
        public int? TipoOperacaoCodBarrasMalote { get; set; }
        public string CodigoIdentificacaoCliente { get; set; }
        public bool? LacreObrigatorio { get; set; }
        public Guid? UltimoHistoricoContatoMatriz { get; set; }
        public bool? OptanteSimplesNacional { get; set; }
        public bool? EmissaoNotaFiscalEletronica { get; set; }
        public DateTime? DataFinalBloqueioOperacional { get; set; }
        public int? TipoServicoOperacional { get; set; }
        public string DescricaoContrato { get; set; }
        public DateTime? DataDaNovaNegociacao { get; set; }
        public string ColaboradorAlteracaoDataReajuste { get; set; }
        public int? CourrierPadrao { get; set; }
        public bool? GerarCte { get; set; }
        public double? ValorFornecimentoMaoObra { get; set; }
        public int? DiaVencimentoFaturaMaoObra { get; set; }
        public Guid? MatrizCobranca { get; set; }
        public double? ValorMensalContrato { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? CartaoPostagemCorreios { get; set; }
        public int? GrupoCliente { get; set; }
        public string IDSF { get; set; }
        public string IDConta { get; set; }
        public bool? Sinc { get; set; }
        public string Identidade { get; set; }

        public Guid Id { get; set; }

        public bool Efetiva()
        {
            // Bloqueios Operacional / Suspensao de Faturamento
            if (BloqueioOperacional == null || BloqueioOperacional.Value)
                return false;

            return this.Situacao == (int)SituacaoEnum.Ativa;
        }

        public ICollection<string> AtendimentosSemana
        {
            get
            {
                return !string.IsNullOrEmpty(FrequenciaMatriz) ? FrequenciaMatriz.Split(',') : new string[0];
            }
        }

        public bool IsValid()
        {
            // Implementar fluent validation
            throw new NotImplementedException();
        }        

        public enum SituacaoEnum
        {
            Ativa = 1,
            Inativa = 2,
            Outros = 3
        }
    }
}
