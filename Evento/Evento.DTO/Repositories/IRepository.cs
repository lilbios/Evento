using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evento.DTO.Repositories
{
    public interface IRepository<TEntity>
      where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task Delete(object id);

        Task<TEntity> GetByID(object id);
    }
}
