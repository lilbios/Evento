using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class AccountService:IAccountService<User>
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountService(UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;

        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterNewUser(User model, string password)
        {
            var  isAwaliableCreate = await userManager.CreateAsync(model, password);
            return isAwaliableCreate;
        }

        public async Task SingIn(User model, bool isPersistent)
        {
            await signInManager.SignInAsync(model, false);
        }

        public async Task<SignInResult> SingInWithPassword(string email, string password, bool isRememberUser, bool lockoutOnFailure)
        {
            var isAuthenticated =  await signInManager.PasswordSignInAsync(email, password, isRememberUser, lockoutOnFailure);
            return isAuthenticated;
        }
    }
}
