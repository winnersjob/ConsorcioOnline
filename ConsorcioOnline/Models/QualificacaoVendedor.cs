using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    class QualificacaoVendedor
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public Int32 IdCarta { get; set; }
        [Required]
        public Int32 IdComprador { get; set; }
        [Required]
        public Int32 IdVendedor { get; set; }
        [Required]
        public int Pontuacao { get; set; }
        [Required]
        public string ObservacaoComprador { get; set; }
    }
}
