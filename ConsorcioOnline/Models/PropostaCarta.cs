using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class PropostaCarta
    {

        public enum enStatusProposta { EmAnalise=1,Aprovada=2,Cancelada=3,EmTransferencia=4,Concluida=5 }

        [DataMember]
        [Key]
        public long Id { get; set; }
        [DataMember]
        [Required]
        public long IdCarta { get; set; }
        [DataMember]
        [Required]
        public long IdVendedor { get; set; }
        [DataMember]
        public long IdComprador { get; set; }
        [DataMember]
        public int StatusProposta { get; set; }
        [DataMember]
        public string MensagemProposta { get; set; }
        [DataMember]
        public string NomeVendedor { get; set; }
        [DataMember]
        public string NomeComprador { get; set; }
    }
}
