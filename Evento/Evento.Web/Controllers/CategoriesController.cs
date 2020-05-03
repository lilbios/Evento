using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evento.DAL;
using Evento.Models.Entities;
using Evento.BLL.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Localization;
using Evento.BLL.Services;
using Evento.Web.Models.Categories;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Evento.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class CategoriesController : BaseController
    {
        private ICategoryService<Category> caregoryService;
        private readonly IMapper mapper;
        private static readonly IStringLocalizer<BaseController> _localizer;
        public CategoriesController(ICategoryService<Category> caregoryService, IMapper mapper) : base(_localizer)
        {

            this.caregoryService = caregoryService;
            this.mapper = mapper;
        }

        // GET: Categories
        public async Task<IActionResult> Index( string searchString)
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
            if (id == null)
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

        public async Task<IActionResult> Create(CreateViewModel viewModel, IFormFile Image)
        {
            if (ModelState.IsValid)
            {

                var newCat = mapper.Map<Category>(viewModel);

                if (Image != null)

                {
                    if (Image.Length > 0)
                    {

                        byte[] p1 = null;
                        using (var fs1 = Image.OpenReadStream())
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                        newCat.CategoryPhoto = p1;

                    }
                }

                await caregoryService.AddCategory(newCat);
            }
           
            return View(viewModel);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
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
        public async Task<IActionResult> Edit(int id, CreateViewModel category, IFormFile Image)
        {

            if (ModelState.IsValid)
            {

                var newCat = mapper.Map<Category>(category);
                try
                {



                    if (Image != null)

                    {
                        if (Image.Length > 0)
                        {

                            byte[] p1 = null;
                            using (var fs1 = Image.OpenReadStream())
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                            newCat.CategoryPhoto = p1;

                        }
                    }
                    await caregoryService.EditCategory(id, newCat);

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
            if (id == null)
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

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await caregoryService.DeleteCategory(id);
           
            return RedirectToAction(nameof(Index));
        }

        //private bool CategoryExists(int id)
        //{
        //    return _context.Categories.Any(e => e.Id == id);
        //}
    }
}
