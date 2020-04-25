using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Users
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DataOfBirth { get; set; }

        public string Email { get; set; }
    }
}
