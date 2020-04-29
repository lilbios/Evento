using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IAccountService<T> where T: class
    {

        public Task<SignInResult> SingInWithPassword(string email,string password, bool isRememberUser, bool lockoutOnFailure);
        public Task SingIn(T model,bool isPersistent);
        public Task<IdentityResult> RegisterNewUser(T model, string password);
        public Task LogOut();
    }
}
