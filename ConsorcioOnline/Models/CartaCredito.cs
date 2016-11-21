using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class CartaCredito
    {

        public enum enStatusCarta { Em_Analise = 1, Publicada = 2, Reprovada = 3 };

        [DataMember]
        [Key]
        public long Id { get; set; }
        [DataMember]
        [Required]
        public long IdVendedor { get; set; }
        [Display(Name ="Adm. do Consorcio")]
        [DataMember]
        [Required]
        public int AdmConsorcio { get; set; }
        [Display(Name = "Tipo do Consorcio")]
        [DataMember]
        [Required]
        public int TipoConsorcio { get; set; }
        [Display(Name = "Status")]
        [DataMember]
        [Required]
        public int StatusCarta { get; set; }
        [DataMember]
        [Required]
        public string Cidade { get; set; }
        [DataMember]
        [Required]
        public string UF { get; set; }
        [Display(Name = "Valor do Credito")]
        [DataMember]
        [Required]
        public decimal ValorCredito { get; set; }
        [Display(Name = "Valor da Entrada")]
        [DataMember]
        [Required]
        public decimal ValorEntrada { get; set; }
        [Display(Name = "Parcelas")]
        [DataMember]
        [Required]
        public int QtdParcelas { get; set; }
        [Display(Name = "R$ Parcelas")]
        [DataMember]
        [Required]
        public decimal ValorParcela { get; set; }
        [Display(Name = "Saldo da Carta")]
        [DataMember]
        [Required]
        public decimal SaldoCarta { get; set; }
        [DataMember]
        [Required]
        public string Indexador { get; set; }
        [DataMember]
        [Required]
        public decimal Honorarios { get; set; }
        [Display(Name = "% Juros")]
        [DataMember]
        [Required]
        public decimal TaxaJuros { get; set; }

        public List<AdmConsorcio> AdmConsorcios { get; set; }
        public List<TipoConsorcio> TipoConsorcios { get; set; }
        public List<StatusCarta> StatusCartas { get; set; }
        
    }
}
