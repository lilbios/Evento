using Evento.BLL.Interfaces;
using AutoMapper;
using Evento.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Evento.BLL.Services
{
    public class CategoryService : ICategoryService<Category>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddCategory(Category categoryDTO)
        {
            var category = mapper.Map<Category>(categoryDTO);
            await unitOfWork.Categories.Create(category);
        }

        public async Task DeleteCategory(int id)
        {

            await unitOfWork.Categories.Delete(id);
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await unitOfWork.Categories.GetByID(id);
            return category;
        }

        public async Task<ICollection<Category>> GetCategoryByTitle(string search)
        {
            var categoryList = await unitOfWork.Categories.GetByCondition(s => s.Title.Contains(search));
            return categoryList.OrderBy(s => s.Title).ToList();
        }
        public async Task EditCategory(int id, Category categoryDTO)
        {
            var category = await unitOfWork.Categories.GetByID(id);
             categoryDTO =  mapper.Map<Category>(categoryDTO);
            category.Title = categoryDTO.Title;
            category.CategoryPhoto= categoryDTO.CategoryPhoto;
            await unitOfWork.Categories.Update(category);
        }

        public async Task<ICollection<Category>> GetAllCategories()
        {
            var categoryList = await unitOfWork.Categories.GetAll();
            return categoryList.ToList();
        }
    }
}
