using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evento.BLL;
using Evento.BLL.Accounts;
using Evento.BLL.Accounts.DTO;
using Evento.Models.Entities;
using Evento.Web.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountsService _accountsService;

        public AccountController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var registerResult = await _accountsService.Register(model);

                if (registerResult == "Ok")
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in registerResult)
                    {
                        ModelState.AddModelError(string.Empty, error.ToString());
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginDTO { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var authentication = await _accountsService.Login(model);

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
                    ModelState.AddModelError(String.Empty, "Неправильный логин и (или) пароль");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountsService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}