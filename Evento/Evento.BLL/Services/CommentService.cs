using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class CommentService : ICommentService<Comment>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CommentService( IUnitOfWork _unitOfWork,IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;

        }
        public async Task AddNewComment(Comment _comment)
        {
            var comment = mapper.Map<Comment>(_comment);
            await unitOfWork.Comments.Create(comment);
        }

        public async Task DeleteComment(object id)
        {
            var comment = await unitOfWork.Comments.GetByID(id);
            await unitOfWork.Comments.Delete(comment);
        }

        public async Task EditComment(object id,Comment Comment)
        {

            var comment =await unitOfWork.Comments.GetByID(id);
            comment = mapper.Map<Comment>(Comment);
            await unitOfWork.Comments.Update(comment);

        }

        public async Task<ICollection<Comment>> GetEventComments(int eventId)
        {
            var eventList = await unitOfWork.Comments.GetByCondition(x => x.Subscription.EventId == eventId);
            return eventList.ToList();
        }

       
}
}
