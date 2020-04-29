using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.DTO
{
    public class SubscriptionDTO : EntityDTO
    {
        public string EventComment { get; set; }
        public DateTime CommentTime { get; set; }
        public bool IsModified { get; set; }
    }
}
