using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.DTO.Entities
{
    public class TagEvent:Entity
    {
        public Event Event { get; set; }
        public int EventId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
