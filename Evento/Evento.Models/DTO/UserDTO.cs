using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.DTO
{
    public class UserDTO : IdentityUser

    {
        public string FirstName { get; set; }


        public string LastName { get; set; }

        public DateTime DataOfBirth { get; set; }
    }
}
