using Evento.Web.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Base
{
    public class CollectionViewModel<T>
    {
        public ICollection<T> Items { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
