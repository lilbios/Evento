using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.Models.Entities
{
    public class Tag : Entity
    {
        [Required]
        public string TagName { get; set; }

        public virtual ICollection<TagEvent> TagEvents { get; set; }
    }
}
