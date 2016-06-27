using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace ConsorcioOnline.Models
{
    [DataContract]
    public class Users
    {
        [DataMember]
        [Key]
        public string Id { get; set; }
        [DataMember]
        [Required]
        public string Nome { get; set; }
        [DataMember]
        public string Apelido { get; set; }
        [DataMember]
        [Required]
        public int FisJur { get; set; }
        [DataMember]
        public string CPF { get; set; }
        [DataMember]
        public string CNPJ { get; set; }
        [DataMember]
        public string IE { get; set; }
        [DataMember]
        public bool Blocked { get; set; }
    }
}
