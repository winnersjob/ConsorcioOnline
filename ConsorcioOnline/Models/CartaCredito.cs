using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class CartaCredito
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public Int32 IdVendedor { get; set; }
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
        public double ValorCredito { get; set; }
        [Required]
        public double ValorEntrata { get; set; }
        [Required]
        public int QtdParcelas { get; set; }
        [Required]
        public double ValorParcela { get; set; }
        [Required]
        public double SaldoCarta { get; set; }
        [Required]
        public string Indexador { get; set; }
        [Required]
        public double Honorarios { get; set; }
        [Required]
        public double TaxaJuros { get; set; }
    }
}
