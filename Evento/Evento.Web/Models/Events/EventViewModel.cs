using Evento.Models.Entities;
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

        public string Place { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }
        public string Tags { get; set; }
        public bool IsOwner { get; set; }
        public bool IsSubscribed { get; set; }
        public byte[] Photo { get; set; }

    }
}
