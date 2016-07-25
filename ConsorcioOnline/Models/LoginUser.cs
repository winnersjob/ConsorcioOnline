using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class LoginUser
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]        
        public string Nome { get; set; }
        [DataMember]
        [Display(Name = "Nome de Usuário:")]
        public string UserName { get; set; }
        [DataMember]
        [Display(Name = "Senha:")]
        public string Password { get; set; }

    }
}
