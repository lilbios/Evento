using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.Entities
{
    public class TagEvent : Entity
    {
        public virtual Event Event { get; set; }

        public int EventId { get; set; }

        public virtual Tag Tag { get; set; }

        public int TagId { get; set; }
    }
}
