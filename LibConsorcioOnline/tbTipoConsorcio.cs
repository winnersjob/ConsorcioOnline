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
    
    public partial class tbTipoConsorcio
    {
        public tbTipoConsorcio()
        {
            this.tbCartaCredito = new HashSet<tbCartaCredito>();
        }
    
        public int cd_tipoconsorcio { get; set; }
        public string de_tipoconsorcio { get; set; }
        public int cd_grupoconsorcio { get; set; }
    
        public virtual ICollection<tbCartaCredito> tbCartaCredito { get; set; }
        public virtual tbGrupoConsorcio tbGrupoConsorcio { get; set; }
    }
}
