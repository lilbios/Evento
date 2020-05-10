using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using Evento.Web.Models.Memorizes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Web.Controllers
{
    public class MemoraizesController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IMemorizeService memorizeService;
        private readonly ISubscriptionService subscriptionService;
        public MemoraizesController(UserManager<User> userManager,
            IMemorizeService memorizeService, ISubscriptionService subscriptionService)
        {
            this.userManager = userManager;
            this.memorizeService = memorizeService;
            this.subscriptionService = subscriptionService;
        }



        //public Task<IActionResult> VisitedEvents(int page = 1) {

        //    return View();
        //}

        [HttpGet]
        public IActionResult CreateNewMemorize()
        {
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateNewMemorize(MemorizeViewModel memorizeViewModel)
        //{

        //    if (ModelState.IsValid)
        //    {

        //    }
        //    return View(memorizeViewModel);
        //}

    }
}