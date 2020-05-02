using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Events
{
    public class EventViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public double Latitute { get; set; }

        public double Longtitute { get; set; }
       
        public string[] Tags { get; set; }

         public byte[] Photo { get; set; }
    }
}
