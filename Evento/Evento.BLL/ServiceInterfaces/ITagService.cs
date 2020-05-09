using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ITagService
    {
        public Task<Tag> AddTag(Tag tag);
        public Task RemoveTag(int tagId);
        public Task AttachTagToEvent(Tag tag, Event _event);

        public Task<Tag> FindTagByName(string name);
        public Task<bool> HasTag(string name);


    }
}
