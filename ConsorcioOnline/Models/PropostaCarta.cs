﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class PropostaCarta
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public Int32 IdCarta { get; set; }
        [Required]
        public Int32 IdVendedor { get; set; }
        [Required]
        public Int32 IdComprador { get; set; }
        [Required]
        public int StatusProposta { get; set; }
        [Required]
        public string MensagemProposta { get; set; }
    }
}
