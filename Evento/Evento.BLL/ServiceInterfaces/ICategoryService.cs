
using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ICategoryService
    {
        public Task AddCategory(Category category);
        public Task DeleteCategory(int id);
        public Task EditCategory(int id, Category category);
        public Task<Category> GetCategory(int id);
        public Task<ICollection<Category>> GetAllCategories();
        public Task<ICollection<Category>> GetCategoryByTitle(string search);


    }
}
