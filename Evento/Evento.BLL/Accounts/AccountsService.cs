using AutoMapper;
using Evento.BLL.Accounts.DTO;
using Evento.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Evento.BLL.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly SignInManager<User> signInManager;


        public AccountsService(UserManager<User> userManager,
            SignInManager<User> signInManager, IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
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

        public async Task<User> GetUser(string id)
        {
            return await unitOfWork.Users.GetObjectLazyLoad(u=> u.Id == id, u=>u.Subscriptions);
        }
    }
}
