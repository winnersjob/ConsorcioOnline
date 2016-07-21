using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class Filters
    {
        public Decimal ValorCreditoDe { get; set; }
        public Decimal ValorCreditoAte { get; set; }
    }
}
