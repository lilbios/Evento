using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Events
{
    public class PlaceViewModel
    {
        [Required]
        public string Place { get; set; }
        [Required]
        public  string Latitude { get; set; }
        [Required]
        public string Longtitude { get; set; }
        [Required]
        public int EventId { get; set; }
    }
}
