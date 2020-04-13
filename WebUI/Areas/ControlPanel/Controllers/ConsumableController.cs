using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.ConsumableModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class ConsumableController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IConsumableRepository consumableRepository;
        private readonly IConsumableLogic consumableLogic;
        private readonly int pageSize = 5;

        public ConsumableController(IAccountRepository accountRepository, IAccountLogic accountLogic, IAccountPermissionRepository accountPermissionRepository,
            IEmployeeLogic employeeLogic, IConsumableRepository consumableRepository, IConsumableLogic consumableLogic)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.employeeLogic = employeeLogic;
            this.consumableRepository = consumableRepository;
            this.consumableLogic = consumableLogic;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = await accountLogic.GetAccountById(id);
            var user = await employeeLogic.GetEmployeeById(account.EmployeeId);
            account.Permissions = (await accountPermissionRepository.GetAccountPermissions()).Where(ap => ap.AccountId == account.Id).ToList();
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task<ActionResult> Index(string search = "", int page = 1)
        {
            await PopulateAccountInfo();
            var consumables = await consumableRepository.GetConsumables();
            ConsumablesListViewModel model = ModelFromData.GetListViewModel(consumables, search, page, pageSize);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            return View(new ConsumableViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(ConsumableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var consumable = DataFromModel.GetData(model);
                await consumableRepository.Add(consumable);
                return RedirectToAction("Index", "Consumable", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var consumable = await consumableLogic.GetConsumableById(id);
            ConsumableViewModel model = ModelFromData.GetViewModel(consumable);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ConsumableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var consumable = DataFromModel.GetData(model);
                await consumableRepository.Update(consumable);
                return RedirectToAction("Index", "Consumable", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var consumable = await consumableLogic.GetConsumableById(id);
            ConsumableViewModel model = ModelFromData.GetViewModel(consumable);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ConsumableViewModel model)
        {
            var consumable = await consumableLogic.GetConsumableById(id);
            await consumableRepository.Delete(consumable);
            return RedirectToAction("Index", "Consumable", new { Area = "ControlPanel" });
        }
    }
}