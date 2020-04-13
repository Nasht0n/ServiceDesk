using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.CampusModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class CampusController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly ICampusRepository campusRepository;
        private readonly ICampusLogic campusLogic;
        private readonly int pageSize = 5;

        public CampusController(IAccountRepository accountRepository, IAccountLogic accountLogic, IAccountPermissionRepository accountPermissionRepository,
            IEmployeeLogic employeeLogic, ICampusRepository campusRepository, ICampusLogic campusLogic)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.employeeLogic = employeeLogic;
            this.campusRepository = campusRepository;
            this.campusLogic = campusLogic;
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
            var campuses = await campusRepository.GetCampuses();
            CampusesListViewModel model = ModelFromData.GetListViewModel(campuses, search, page, pageSize);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            return View(new CampusViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(CampusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var campus = DataFromModel.GetData(model);
                await campusRepository.Add(campus);
                return RedirectToAction("Index", "Campus", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var campus = await campusLogic.GetCampusById(id);
            CampusViewModel model = ModelFromData.GetViewModel(campus);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(CampusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var campus = DataFromModel.GetData(model);
                await campusRepository.Update(campus);
                return RedirectToAction("Index", "Campus", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var campus = await campusLogic.GetCampusById(id);
            CampusViewModel model = ModelFromData.GetViewModel(campus);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, CampusViewModel model)
        {
            var campus = await campusLogic.GetCampusById(id);
            await campusRepository.Delete(campus);
            return RedirectToAction("Index", "Campus", new { Area = "ControlPanel" });
        }
    }
}