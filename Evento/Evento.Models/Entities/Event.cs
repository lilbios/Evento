using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.Models.Entities
{
    public class Event : Entity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateFinish { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public double Latitute { get; set; }

        [Required]
        public double Longtitute { get; set; }

        [Required]
        public virtual Category Category { get; set; }
        public byte[] Photo { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<TagEvent> TagEvents { get; set; }
    }
}
