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
    
    public partial class tbGrupoConsorcio
    {
        public tbGrupoConsorcio()
        {
            this.tbTipoConsorcio = new HashSet<tbTipoConsorcio>();
        }
    
        public int cd_grupoconsorcio { get; set; }
        public string de_grupoconsorcio { get; set; }
    
        public virtual ICollection<tbTipoConsorcio> tbTipoConsorcio { get; set; }
    }
}
