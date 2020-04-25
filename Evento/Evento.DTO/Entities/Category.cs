using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.DTO.Entities
{
    public class Category : Entity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string CategoryPhoto { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
