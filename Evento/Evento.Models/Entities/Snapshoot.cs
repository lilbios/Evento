using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Models.Entities
{
    public class Snapshoot : Entity
    {
        public int MemorizeId{get;set;}
        public Memorize Memorize { get; set; }
        public byte[] SnapshootPhoto { get; set; }

    }
}
