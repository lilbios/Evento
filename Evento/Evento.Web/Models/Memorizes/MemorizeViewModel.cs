using Evento.Models.Entities;
using Evento.Web.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Memorizes
{
    public class MemorizeViewModel
    {

        [Required]
        public string Title { get; set; }

        public string MemorizeComment { get; set; }


    }
}
