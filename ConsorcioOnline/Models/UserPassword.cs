using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsorcioOnline.Models
{
    public class UserPassword
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Blocked { get; set; }
    }
}
