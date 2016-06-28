using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class Users
    {        
        [Key]
        [DataMember]
        public string Id { get; set;}        
        [Required]
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Apelido { get; set; }        
        [Required]
        [DataMember]
        public int FisJur { get; set; }
        [DataMember]
        public string CPF { get; set; }
        [DataMember]
        public string CNPJ { get; set; }
        [DataMember]
        public string IE { get; set; }
        [DataMember]
        public int Blocked { get; set; }
    }
}
