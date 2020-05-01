using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Evento.Web;
using Evento.Web.LanguageResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Evento.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IStringLocalizer<BaseController> _localizer;

        public BaseController(IStringLocalizer<BaseController> localizer)
        {
            _localizer = localizer;
         
        }
        public string GetCulture()
        {
            return $"CurrentCulture:{CultureInfo.CurrentCulture.Name}, CurrentUICulture:{CultureInfo.CurrentUICulture.Name}";
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}