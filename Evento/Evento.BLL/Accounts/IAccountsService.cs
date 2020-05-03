using Evento.BLL.Accounts.DTO;
using Evento.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Accounts
{
    public interface IAccountsService
    {
        Task<IdentityResult> Register(RegisterDTO model);

        Task<SignInResult> Login(LoginDTO model);

        Task Logout();
    }
}