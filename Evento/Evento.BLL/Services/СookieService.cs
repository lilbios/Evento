using Evento.BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL.Services
{
    public class СookieService:ICookieService
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public CookieOptions CookieOptions { get; set; }

        public СookieService()
        {
            CookieOptions = new CookieOptions();
        }

        public void SetExpireTime(int time)
        {
            CookieOptions.Expires = DateTime.Now.AddDays(time);
        }
    }
}
