//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibConsorcioOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbQualificacaoVendedor
    {
        public long cd_qualvendedor { get; set; }
        public long cd_vendedor { get; set; }
        public long cd_comprador { get; set; }
        public long cd_cartacredito { get; set; }
        public int nu_pontuacao { get; set; }
        public string de_observacaocomprador { get; set; }
    
        public virtual tbCartaCredito tbCartaCredito { get; set; }
        public virtual tbComprador tbComprador { get; set; }
        public virtual tbVendedor tbVendedor { get; set; }
    }
}
