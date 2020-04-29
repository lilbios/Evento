using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.Models.Entities
{
    public class Location : Entity
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public float Latitute { get; set; }

        [Required]
        public float Longtitute { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
