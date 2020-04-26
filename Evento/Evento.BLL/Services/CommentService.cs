using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class CommentService : ICommentService<Comment>
    {
        public Task AddNewComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task EditComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Comment>> GetEventComments(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
