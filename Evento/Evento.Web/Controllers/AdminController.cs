using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.BLL.Accounts;
using Evento.BLL.Accounts.DTO;
using Evento.BLL.ServiceInterfaces;
using Evento.BLL.Services;
using Evento.Models.Entities;
using Evento.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;

namespace Evento.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<User> userManager;
        private IUserValidator<User> userValidator;
        private IPasswordHasher<User> passwordHasher;
        private readonly IAccountsService accountsService;
        private IPasswordValidator<User> passwordValidator;
        private readonly IEmailSender _emailSender;


        public AdminController(IAccountsService accountsServ,
            UserManager<User> usrMgr, IPasswordHasher<User> passwordHash,
            IPasswordValidator<User> passwordVal, IUserValidator<User> userValid, IEmailSender emailSender)
        {
            accountsService = accountsServ;
            userManager = usrMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordVal;
            userValidator = userValid;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View(userManager.Users.ToList());
        }

        public async Task<IActionResult> Create(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var registerResult = await accountsService.Register(model);

                if (registerResult.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in registerResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Update(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password, int age, string country, string salary)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult validEmail = null;
                if (!string.IsNullOrEmpty(email))
                {
                    validEmail = await userValidator.ValidateAsync(userManager, user);
                    if (validEmail.Succeeded)
                        user.Email = email;
                    else
                        Errors(validEmail);
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    else
                        Errors(validPass);
                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (validEmail != null && validPass != null && validEmail.Succeeded && validPass.Succeeded && !string.IsNullOrEmpty(salary))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");

            return View(user);
        }

        void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }
        public async Task<ActionResult> Back()
        {
            DateTime d = DateTime.Now;
            string dd = d.Day + "-" + d.Month + "-" + d.Hour;

            string aaa = @"Server=DESKTOP-AGJ5FF3\SQLEXPRESS;Initial Catalog=ComeTogetherDB;Persist Security Info=False;User ID=User;Password=User;MultipleActiveResultSets=True;Encrypt=False;TrustServerCertificate=False;";
            SqlConnection con = new SqlConnection(aaa);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["BackupCatalogDBSoft.Properties.Settings."+dbname+"ConnectionString"].ToString();

            con.Open();
            string str = "USE " + "BranchDB" + ";";
            string str1 = "BACKUP DATABASE " + "ComeTogetherDb" +
                " TO DISK = 'E:\\" + "ComeTogetherDB" + "_" + dd +
                ".Bak' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'Full Backup of " + "BranchDB" + "';";
            ViewBag.Path = "E:\\" + "ComeTogetherDB" + "_" + dd + ".Bak";
            SqlCommand cmd1 = new SqlCommand(str, con);
            SqlCommand cmd2 = new SqlCommand(str1, con);
            await cmd1.ExecuteNonQueryAsync();
            await cmd2.ExecuteNonQueryAsync();

            con.Close();
            return View();

        }

        public ActionResult OtherAction()
        {
            return View(GetData("OtherAction"));
        }

        private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            dict.Add("Action", actionName);
            dict.Add("Пользователь", HttpContext.User.Identity.Name);
            dict.Add("Аутентифицирован?", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Тип аутентификации", HttpContext.User.Identity.AuthenticationType);
            dict.Add("В роли Users?", HttpContext.User.IsInRole("Users"));

            return dict;
        }
        public async Task<ActionResult> Email(string Content)
        {
            if (!String.IsNullOrEmpty(Content))
            {
                var id = userManager.GetUserId(User);
                var user = await userManager.FindByIdAsync(id);
                string[] send = userManager.Users.Select(x => x.Email).ToArray();
                var message = new Message( send, "Message from Evento", Content);
                _emailSender.SendEmail(message);
            }
            return View();
        }
    }
}