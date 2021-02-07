﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.BLL;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using Evento.Web.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ServiceManager serviceManager;
        private SignInManager<User> signInManager;
        public AccountController(IUnitOfWork unitOfWork,UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            serviceManager = new ServiceManager(unitOfWork, userManager, signInManager);
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DataOfBirth = model.DataOfBirth,
                    Email = model.Email,
                    UserName = model.Email
                };

                var createResult = await serviceManager.UserAccounts.RegisterNewUser(user, model.Password);

                if (createResult.Succeeded)
                {
                    await serviceManager.UserAccounts.SingIn(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authentication = await serviceManager.UserAccounts.SingInWithPassword(model.Email, model.Password,
                    model.RememberMe, false);
                
                if (authentication.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await serviceManager.UserAccounts.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}