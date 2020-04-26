using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class CommentService : ICommentService<Comment>
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentService( IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
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

        public Task<IEnumerable<Comment>> GetEventComments(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
