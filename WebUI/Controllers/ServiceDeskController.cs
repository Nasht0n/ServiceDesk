using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels;
using BusinessLogic.Abstract;

namespace WebUI.Controllers
{
    public class ServiceDeskController : Controller
    {
        private readonly IAccountLogic accountLogic;

        public ServiceDeskController(IAccountLogic accountLogic)
        {
            this.accountLogic = accountLogic;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {
            return View(new ContactViewModel());
        }
        [HttpPost]
        public ActionResult Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                MailSender.SendMessage(model.Email, model.Fullname, model.Message);
            }
            ModelState.Clear();
            return View();
        }
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Авторизация
                var account = await accountLogic.GetAccount(model.Username, model.Password);
                if (account == null)
                {
                    ModelState.AddModelError("", "Пользователь не найден.");
                }
                else if (!account.IsEnabled)
                {
                    ModelState.AddModelError("", "Учетная запись пользователя отключена.");
                }
                else
                {
                    ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Id.ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, account.Id.ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "OWIN Provider", ClaimValueTypes.String));
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);

                    if (account.ChangePasswordOnNextEnter)
                    {
                        return RedirectToAction("ChangePassword", "ServiceDesk", new { Area = "", id = account.Id });
                    }
                    else
                    {
                        account.LastEnterDateTime = DateTime.Now;
                        await accountLogic.Save(account);
                        // accountService.UpdateAccount(account);
                        return RedirectToAction("Index", "Dashboard", new { Area = "" });
                    }
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "ServiceDesk");
        }
        [Authorize]
        public ActionResult ChangePassword(int id)
        {
            return View(new ChangePasswordViewModel { AccountId = id });
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var account = await accountLogic.GetAccount(model.AccountId);
            if (account != null && model.NewPassword.ToLower().Equals(model.RepeatNewPassword.ToLower()))
            {
                account.Password = model.NewPassword;
                account.DateChangePassword = DateTime.Now;
                account.ChangePasswordOnNextEnter = false;
                account.LastEnterDateTime = DateTime.Now;
                account = await accountLogic.Save(account);
                return RedirectToAction("Index", "Dashboard", new { Area = "" });
            }
            return View();
        }
    }
}