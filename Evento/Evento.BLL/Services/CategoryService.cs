using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class CategoryService : ICategoryService<Category>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public Task AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
