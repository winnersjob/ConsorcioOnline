using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class UserPassword
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [Required]
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string PasswordConfirm { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
        [DataMember]
        public bool Blocked { get; set; }
    }
}
