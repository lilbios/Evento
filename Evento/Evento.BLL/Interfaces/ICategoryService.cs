using Evento.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ICategoryService<T> where T : class
    {
        public Task AddCategory(Category category);
        public Task DeleteCategory(int id);
        public Task EditCategory(int id, T category);


    }
}
