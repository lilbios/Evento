using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.DTO.Entities
{
    public class Memorize : Entity
    {
        [Required(ErrorMessage = "Required field")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string MemorizeComment { get; set; }

        public string MemorizePhoto { get; set; }

        public Subscription Subscription { get; set; }

        public int SubscriptionId { get; set; }
    }
}
