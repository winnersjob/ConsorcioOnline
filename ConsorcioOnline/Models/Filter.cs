using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class Filter
    {
        [DataMember]
        [Display(Name ="De: ")]
        public Decimal ValorCreditoDe { get; set; }
        [DataMember]
        [Display(Name = "Até: ")]
        public Decimal ValorCreditoAte { get; set; }
        [DataMember]
        public string IdUser { get; set; }
        [DataMember]
        public int StatusCarta { get; set; }
        [DataMember]
        public int RemoveProposta { get; set; }

    }
}
