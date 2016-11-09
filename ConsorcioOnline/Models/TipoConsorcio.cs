using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class TipoConsorcio
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
    }
}
