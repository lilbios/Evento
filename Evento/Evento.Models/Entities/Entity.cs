using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evento.Models.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
