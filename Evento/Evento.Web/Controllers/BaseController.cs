using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.Web.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Evento.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IStringLocalizer<BaseController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        public BaseController(IStringLocalizer<BaseController> localizer,
                   IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}