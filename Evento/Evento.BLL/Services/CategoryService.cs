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
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCategory(Category category)
        {
            Category _category = new Category();
            _category.Title = category.Title;
            _category.CategoryPhoto = category.CategoryPhoto;
           await _unitOfWork.Categories.Create(_category);
        }

        public async Task DeleteCategory(int id)
        {

            await _unitOfWork.Categories.Delete(id);
        }

        public async Task EditCategory(int id, Category category)
        {
            var _category = _unitOfWork.Categories.GetByID(id);
            _category.Result.Title = category.Title;
            if (category.CategoryPhoto != null)
            {
                _category.Result.CategoryPhoto = category.CategoryPhoto;
            }
           _unitOfWork.Categories.Update(_category.Result);
        }
    }
}
