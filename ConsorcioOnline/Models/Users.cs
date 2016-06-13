using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class Users
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Apelido { get; set; }
        [Required]
        public int FisJur { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public bool Blocked { get; set; }
    }
}
