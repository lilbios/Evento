using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ICommentService<T> where T : class
    {
        public Task<ICollection<T>> GetEventComments(int eventId);
        public Task AddNewComment(T comment);
        public Task DeleteComment(T comment);
        public Task EditComment(T comment);

    }
}
