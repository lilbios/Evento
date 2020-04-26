using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evento.DTO.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public DateTime DataOfBirth { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
