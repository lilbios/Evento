using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Evento.Models.Entities;
using Evento.BLL.Interfaces;
using AutoMapper;
using Evento.Web.Models.Categories;
using Microsoft.AspNetCore.Http;
using Evento.BLL.Third_part;

namespace Evento.Web.Controllers
{
    
    public class CategoriesController : Controller
    {
        private readonly IMapper mapper;
        private ICategoryService caregoryService;
        
        public CategoriesController(ICategoryService caregoryService, IMapper mapper)
        {
            this.caregoryService = caregoryService;
            this.mapper = mapper;
        }

        // GET: Categories
        public async Task<IActionResult> Index(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                var eventsSearch = await caregoryService.GetCategoryByTitle(searchString);

                return View(eventsSearch);
            }
            var events = await caregoryService.GetAllCategories();
            return View(events);
        }

       
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var category = await caregoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            var detail = mapper.Map<CreateViewModel>(category);
            return View(detail);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateViewModel viewModel, IFormFile image)
        {
            if (ModelState.IsValid)
            {

                var newCat = mapper.Map<Category>(viewModel);

                if (image != null && image.Length > 0 )

                {
                    newCat.CategoryPhoto = ImageConvertor.ConvertImageToBytes(image);  
                }

                await caregoryService.AddCategory(newCat);
                ViewData["Created"] = "Category successfully created";
                return View(viewModel);
            }
           
            return View(viewModel);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var category = await caregoryService.GetCategory(id);
           
            if (category == null)
            {
                return NotFound();
            }
            var edited = mapper.Map<CreateViewModel>(category);
            return View(edited);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateViewModel category, IFormFile image)
        {

            if (ModelState.IsValid)
            {

                var newCat = mapper.Map<Category>(category);
                try
                {

                    if (image != null && image.Length > 0)

                    {
                        newCat.CategoryPhoto = ImageConvertor.ConvertImageToBytes(image);
                    }
                    await caregoryService.EditCategory(id, newCat);
                    ViewData["Edited"] = "Category successfully edited";
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }


        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var category = await caregoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
           // var edited = mapper.Map<CreateViewModel>(category);
            await caregoryService.DeleteCategory(id);
            return View(nameof(Index));
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await caregoryService.DeleteCategory(id);
           
            return RedirectToAction(nameof(Index));
        }

    }
}
