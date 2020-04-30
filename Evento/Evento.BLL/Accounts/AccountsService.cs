using Evento.BLL.Accounts.DTO;
using Evento.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

        public async Task<string> Register(RegisterDTO model)
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

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return "Ok";
            }

            return result.Errors.ToString();
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

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
