using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using Evento.Web.Models.Memorizes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Web.Controllers
{
    public class MemorizesController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IMemorizeService memorizeService;
        private readonly ISubscriptionService subscriptionService;
        public MemorizesController(UserManager<User> userManager,IMapper mapper,
            IMemorizeService memorizeService, ISubscriptionService subscriptionService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.memorizeService = memorizeService;
            this.subscriptionService = subscriptionService;
        }



        //public Task<IActionResult> VisitedEvents(int page = 1) {

        //    return View();
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(MemorizeViewModel  memorizeViewModel)
        {

            var tempt = Request.Form.Files.ToList();
         
            if (ModelState.IsValid)
            {
              
            }
            return View(memorizeViewModel);
        }

    }
}