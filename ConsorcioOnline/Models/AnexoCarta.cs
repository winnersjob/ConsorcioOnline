using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class AnexoCarta
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public Int32 IdCarta { get; set; }
        [Required]
        public string LinkAnexo { get; set; }

    }
}
