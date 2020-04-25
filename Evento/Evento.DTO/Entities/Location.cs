using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.DTO.Entities
{
    public class Location : Entity
    {
        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"^[A-Z]?[a-z]+$")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"^[A-Z]?[a-z]+$")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"^[A-Z]?[a-z]+$")]
        public string Street { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
