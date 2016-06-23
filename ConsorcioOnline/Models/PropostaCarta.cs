using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class PropostaCarta
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long IdCarta { get; set; }
        [Required]
        public long IdVendedor { get; set; }
        [Required]
        public long IdComprador { get; set; }
        [Required]
        public int StatusProposta { get; set; }
        [Required]
        public string MensagemProposta { get; set; }
    }
}
