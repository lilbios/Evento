using Evento.BLL.Accounts.DTO;
using Evento.Models.Entities;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountsService(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                DataOfBirth = model.DataOfBirth
            };

            var result = await userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            var result = await
                    signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            return result;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
