using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evento.DTO.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DataOfBirth { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
