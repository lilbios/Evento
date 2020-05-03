using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Categories
{
    public class CreateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        
        public byte[] CategoryPhoto { get; set; }
    }
}
