using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.Models.Entities
{
    public class Category : Entity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public byte[] CategoryPhoto { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
