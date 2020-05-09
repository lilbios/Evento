using Evento.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ICommentService
    {
        public Task<ICollection<Comment>> GetEventComments(int eventId);
        public Task AddNewComment(Comment comment);
        public Task DeleteComment(object id);
        public Task EditComment(object id, comment);

    }
}
