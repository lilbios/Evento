﻿using Evento.BLL.Interfaces;
using AutoMapper;
using Evento.Models.Entities;
using System.Threading.Tasks;

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

        public async Task EditCategory(int id, Category categoryDTO)
        {
            var category = await unitOfWork.Categories.GetByID(id);
            category = mapper.Map<Category>(categoryDTO);
            await unitOfWork.Categories.Update(category);
        }
    }
}
