using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class Comprador
    {
        [DataMember]
        [Key]
        public long Id { get; set; }
        [DataMember]
        [Required]
        public string IdUser { get; set; }
        [DataMember]
        public string  CreatedAt { get; set; }
        [DataMember]
        [Required]
        public long PositiveFeedback { get; set; }
        [DataMember]
        [Required]
        public long NegativeFeedback { get; set; }
        [DataMember]
        public bool Blocked { get; set; }
    }
}