using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class Comprador
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public string IdUser { get; set; }        
        public DateTime CreatedAt { get; set; }
        [Required]
        public Int32 PositiveFeedback { get; set; }
        [Required]
        public Int32 NegativeFeedback { get; set; }
        public bool Blocked { get; set; }
    }
}
