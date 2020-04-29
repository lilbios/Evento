using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.DTO
{
    public class TagEventDTO : EntityDTO
    {
        public int EventId { get; set; }
        public int TagId { get; set; }
    }
}
