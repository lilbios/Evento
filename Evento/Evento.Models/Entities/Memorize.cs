using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.Models.Entities
{
    public class Memorize : Entity
    {
        [Required]
        public string Title { get; set; }
        public string MemorizeComment { get; set; }


        public virtual Subscription Subscription { get; set; }

        public int SubscriptionId { get; set; }

        public ICollection<Snapshoot> Snapshoots { get; set; }
    }
}
