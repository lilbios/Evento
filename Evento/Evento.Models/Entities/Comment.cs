using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.Entities
{
    public class Comment : Entity
    {
        public string EventComment { get; set; }

        public DateTime CommentTime { get; set; }

        public bool IsModified { get; set; }

        public  Subscription Subscription { get; set; }

        public int SubscriptionId { get; set; }
    }
}
