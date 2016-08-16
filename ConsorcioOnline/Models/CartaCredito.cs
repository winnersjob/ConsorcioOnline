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
        [DataMember]
        [Required]
        public int AdmConsorcio { get; set; }
        [DataMember]
        [Required]
        public int TipoConsorcio { get; set; }
        [DataMember]
        [Required]
        public int StatusCarta { get; set; }
        [DataMember]
        [Required]
        public string Cidade { get; set; }
        [DataMember]
        [Required]
        public string UF { get; set; }
        [DataMember]
        [Required]
        public decimal ValorCredito { get; set; }
        [DataMember]
        [Required]
        public decimal ValorEntrada { get; set; }
        [DataMember]
        [Required]
        public int QtdParcelas { get; set; }
        [DataMember]
        [Required]
        public decimal ValorParcela { get; set; }
        [DataMember]
        [Required]
        public decimal SaldoCarta { get; set; }
        [DataMember]
        [Required]
        public string Indexador { get; set; }
        [DataMember]
        [Required]
        public decimal Honorarios { get; set; }
        [DataMember]
        [Required]
        public decimal TaxaJuros { get; set; }
        
    }
}
