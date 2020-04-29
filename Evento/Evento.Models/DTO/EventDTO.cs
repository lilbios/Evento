using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.DTO
{
    public class EventDTO
    {
        
        public string Title { get; set; }

        
        public DateTime DateStart { get; set; }

        
        public DateTime DateFinish { get; set; }

        
        public string Description { get; set; }

        public int LocationId { get; set; }


        public int CategoryId { get; set; }
    }
}
