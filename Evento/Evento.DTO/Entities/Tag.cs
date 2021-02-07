using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.DTO.Entities
{
    public class Tag : Entity
    {
        [Required]
        public string TagName { get; set; }
        public ICollection<TagEvent> TagEvents { get; set; }
    }
}
