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
    
    public partial class tbAnexoCarta
    {
        public string id_anexo { get; set; }
        public long cd_cartacredito { get; set; }
        public string de_linkanexo { get; set; }
    
        public virtual tbCartaCredito tbCartaCredito { get; set; }
    }
}
