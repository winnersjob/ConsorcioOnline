using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class Filter
    {
        [Display(Name ="De: ")]
        public Decimal ValorCreditoDe { get; set; }
        [Display(Name = "Até: ")]
        public Decimal ValorCreditoAte { get; set; }
        public string IdUser { get; set; }

    }
}
