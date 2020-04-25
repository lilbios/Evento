using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ITagService<T> where T : class
    {
        public Task AddTag(T tag);
        public Task RemoveTag(T tag);


    }
}
