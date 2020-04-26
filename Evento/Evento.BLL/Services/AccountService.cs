using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL.Services
{
    public class AccountService:IAccountService<User>
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
    }
}
