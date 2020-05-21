using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL.ServiceInterfaces
{
    public interface ICookieService
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public CookieOptions CookieOptions { get; set; }
        public void SetExpireTime(int time);
    }
}
