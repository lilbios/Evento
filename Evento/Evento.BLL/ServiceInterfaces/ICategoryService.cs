
using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ICategoryService<T> where T : class
    {
         Task AddCategory(T category);
         Task DeleteCategory(int id);
         Task EditCategory(int id, T category);

        Task<ICollection<T>> GetAllCategories();


    }
}
