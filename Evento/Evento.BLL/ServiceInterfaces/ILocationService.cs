using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ILocationService<T> where T : class
    {
        public Task AddLocation(T location);
        public Task DeleteLocation(int id);
        public Task EditLocation(int id, T location);
    }
}
