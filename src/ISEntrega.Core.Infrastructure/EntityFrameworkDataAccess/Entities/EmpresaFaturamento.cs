using System;

namespace ISEntrega.Core.EntityFrameworkDataAccess.Entities
{
    public class EmpresaFaturamento
    {
        public Guid Oid { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string CodigoCedente { get; set; }
        public int? InicioNossoNumero { get; set; }
        public int? TerminoNossoNumero { get; set; }
        public string CaminhoArquivoLicenca { get; set; }
        public string CaminhoImagemLogotipo { get; set; }
        public string CaminhoImagemCodigoBarra { get; set; }
        public string CaminhoArquivosRetorno { get; set; }
        public string CaminhoArquivoRemessa { get; set; }
        public string PadraoLayoutArquivoRetorno { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public string DigitoIdentificador { get; set; }
        public bool? MostrarISSeINSS { get; set; }
        public Guid? Cidade { get; set; }
        public int? RegimeTributacao { get; set; }
        public string InscricaoMunicipalPrestador { get; set; }
        public Guid? Atividade { get; set; }
        public bool? EmiteNFSe { get; set; }
        public bool? IncentivadorCultural { get; set; }
        public string RNTRC { get; set; }
        public Guid? AtividadeAgenciamento { get; set; }
        public string InscricaoEstatudal { get; set; }
        public string RazaoSocial { get; set; }
        public string Logradouro { get; set; }
        public string NumeroLogradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public Guid? AtividadeMaoObra { get; set; }
    }
}
