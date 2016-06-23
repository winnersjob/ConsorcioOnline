using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class QualificacaoVendedor
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long IdCarta { get; set; }
        [Required]
        public long IdComprador { get; set; }
        [Required]
        public long IdVendedor { get; set; }
        [Required]
        public int Pontuacao { get; set; }
        [Required]
        public string ObservacaoComprador { get; set; }
    }
}
