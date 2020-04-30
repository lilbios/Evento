using Evento.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.DTO.ViewModel
{
   public class EventsWithCategory
    {
        
        public string Title { get; set; }

      
        public DateTime DateStart { get; set; }

       
        public DateTime DateFinish { get; set; }

       
        public string Description { get; set; }

     
        public Location Location { get; set; }

        public int LocationId { get; set; }

      
        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<TagEvent> TagEvents { get; set; }
    }
}
