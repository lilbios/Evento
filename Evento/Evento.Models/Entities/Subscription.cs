using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.Entities
{
    public class Subscription : Entity
    {
        public bool IsOwner { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public virtual Event Event { get; set; }

        public int EventId { get; set; }

        public virtual ICollection<Memorize> Memorizes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
