using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.DTO
{
    public class MemorizeDTO : EntityDTO
    {
        public string Title { get; set; }

        public string MemorizeComment { get; set; }

        public string MemorizePhoto { get; set; }


        public int SubscriptionId { get; set; }
    }
}
