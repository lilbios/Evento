using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ITagService<T> where T : class
    {
        public Task<T> AddTag(Tag tag);
        public Task RemoveTag(int tagId);
        public Task AttachTagToEvent(Tag tag, Event _event);

        public Task<T> FindTagByName(string name);
        public Task<bool> HasTag(string name);


    }
}
