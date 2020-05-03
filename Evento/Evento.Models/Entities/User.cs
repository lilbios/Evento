using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evento.Models.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Address { get; set; }

        public DateTime DataOfBirth { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
