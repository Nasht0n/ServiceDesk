using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.ComponentModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IComponentRepository componentRepository;
        private readonly IComponentLogic componentLogic;
        private readonly int pageSize = 5;

        public ComponentController(IAccountRepository accountRepository, IAccountLogic accountLogic, IAccountPermissionRepository accountPermissionRepository,
            IEmployeeLogic employeeLogic, IComponentRepository componentRepository, IComponentLogic componentLogic)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.employeeLogic = employeeLogic;
            this.componentRepository = componentRepository;
            this.componentLogic = componentLogic;
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
            var components = await componentRepository.GetComponents();
            ComponentsListViewModel model = ModelFromData.GetListViewModel(components, search, page, pageSize);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            return View(new ComponentViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(ComponentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var component = DataFromModel.GetData(model);
                await componentRepository.Add(component);
                return RedirectToAction("Index", "Component", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var component = await componentLogic.GetComponentById(id);
            ComponentViewModel model = ModelFromData.GetViewModel(component);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ComponentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var component = DataFromModel.GetData(model);
                await componentRepository.Update(component);
                return RedirectToAction("Index", "Component", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var component = await componentLogic.GetComponentById(id);
            ComponentViewModel model = ModelFromData.GetViewModel(component);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ComponentViewModel model)
        {
            var component = await componentLogic.GetComponentById(id);
            await componentRepository.Delete(component);
            return RedirectToAction("Index", "Component", new { Area = "ControlPanel" });
        }
    }
}