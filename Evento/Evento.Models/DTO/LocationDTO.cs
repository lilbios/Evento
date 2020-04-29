using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.DTO
{
    public class LocationDTO : EntityDTO
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }
        public float Latitute { get; set; }

        public float Longtitute { get; set; }

    }
}
