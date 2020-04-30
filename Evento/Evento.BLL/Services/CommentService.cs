using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AddNewComment(Comment comment)
        {
            Comment _comment = new Comment();
            _comment.EventComment = comment.EventComment;
           _comment.SubscriptionId = comment.SubscriptionId;
           await unitOfWork.Comments.Create(comment);
        }

        public async Task DeleteComment(object id)
        {
            var comment = unitOfWork.Comments.GetByID(id);
            await unitOfWork.Comments.Delete(comment);
        }

        public async Task EditComment(object id,Comment comment)
        {
          
           var _comment = unitOfWork.Comments.GetByID(id);
            _comment.Result.EventComment = comment.EventComment;
             unitOfWork.Comments.Update(_comment.Result);
        
        }

        public async Task<IEnumerable<Comment>> GetEventComments(int eventId)
        {
            var eventList =  unitOfWork.Comments.GetByCondition(x =>x.Subscription.EventId == eventId).ToList();
            return eventList;
        }

       
}
}
