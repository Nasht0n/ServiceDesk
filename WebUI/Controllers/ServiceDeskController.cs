using DataAccess.Concrete;
using System.Diagnostics;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ServiceDeskController : Controller
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

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
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                // Авторизация
                var account = serviceDesk.AccountRepository.Get(a=>a.Username == model.Username && a.Password == model.Password);
                watch.Stop();
                if(account != null)
                {

                }
                else
                {
                    Debug.WriteLine("Пользователь не найден");
                }
            }
            return View();
        }

    }
}