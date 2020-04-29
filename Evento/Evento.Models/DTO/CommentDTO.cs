using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.DTO
{
    public class CommentDTO : EntityDTO
    {
        public string EventComment { get; set; }
        public DateTime CommentTime { get; set; }
        public bool IsModified { get; set; }

        public int SubscriptionId { get; set; }
    }
}
