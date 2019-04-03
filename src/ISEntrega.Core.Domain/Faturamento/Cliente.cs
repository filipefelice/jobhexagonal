using System;

namespace ISEntrega.Core.Domain.Faturamento
{    
    public class Cliente: IAggregateRoot
    {        
        public string IDSF { get; set; }
        public int? Ativo { get; set; }
        public string CEP { get; set; }
        public Guid? Cidade { get; set; }
        public string CNPJ { get; set; }
        public Guid? Estado { get; set; }
        public DateTime? InicioContrato { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Logradouro { get; set; }
        public string NomeFantasia { get; set; }
        public int? OrigemCliente { get; set; }
        public Guid? Pais { get; set; }
        public int? RamoAtividade { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime? TerminoContrato { get; set; }
        public string Website { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public string IDConta { get; set; }
        public string Numero { get; set; }
        public bool? Sinc { get; set; }
        public string Bairro { get; set; }
        public float? ValorContrato { get; set; }
        public Guid? GerenteContas { get; set; }
        public string Identidade { get; set; }

        public Guid Id { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
