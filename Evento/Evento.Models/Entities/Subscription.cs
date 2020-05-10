using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.Entities
{
    public class Subscription : Entity
    {
        public bool IsOwner { get; set; }

        public  User User { get; set; }

        public string UserId { get; set; }

        public  Event Event { get; set; }

        public int EventId { get; set; }

        public  ICollection<Memorize> Memorizes { get; set; }

        public  ICollection<Comment> Comments { get; set; }
    }
}
