using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class CartaCredito
    {
        [Key]
        public Int64 Id { get; set; }
        [Required]
        public Int64 IdVendedor { get; set; }
        [Required]
        public int AdmConsorcio { get; set; }
        [Required]
        public int TipoConsorcio { get; set; }
        [Required]
        public int StatusCarta { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string UF { get; set; }
        [Required]
        public decimal ValorCredito { get; set; }
        [Required]
        public decimal ValorEntrata { get; set; }
        [Required]
        public int QtdParcelas { get; set; }
        [Required]
        public decimal ValorParcela { get; set; }
        [Required]
        public decimal SaldoCarta { get; set; }
        [Required]
        public string Indexador { get; set; }
        [Required]
        public decimal Honorarios { get; set; }
        [Required]
        public decimal TaxaJuros { get; set; }
    }
}
