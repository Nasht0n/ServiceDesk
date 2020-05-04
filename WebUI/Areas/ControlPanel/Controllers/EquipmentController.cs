using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.EquipmentModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IBranchRepository branchRepository;
        private readonly IBranchLogic branchLogic;
        private readonly IEquipmentRepository equipmentRepository;
        private readonly IEquipmentLogic equipmentLogic;
        private readonly IEquipmentTypeRepository equipmentTypeRepository;
        private readonly IEquipmentTypeLogic equipmentTypeLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly int pageSize = 5;

        public EquipmentController
            (
            IAccountRepository accountRepository, IAccountLogic accountLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IBranchRepository branchRepository, IBranchLogic branchLogic,
            IEquipmentRepository equipmentRepository, IEquipmentLogic equipmentLogic,
            IEquipmentTypeRepository equipmentTypeRepository, IEquipmentTypeLogic equipmentTypeLogic,
            IAccountPermissionRepository accountPermissionRepository, IAccountPermissionLogic accountPermissionLogic
            )
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.branchRepository = branchRepository;
            this.branchLogic = branchLogic;
            this.equipmentRepository = equipmentRepository;
            this.equipmentLogic = equipmentLogic;
            this.equipmentTypeRepository = equipmentTypeRepository;
            this.equipmentTypeLogic = equipmentTypeLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.accountPermissionLogic = accountPermissionLogic;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = await accountLogic.GetAccount(id);
            var user = await employeeLogic.GetEmployee(account.EmployeeId);
            account.Permissions = await accountPermissionLogic.GetPermissions(account);

            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.CanEditRequest = account.Permissions.Where(p => p.PermissionId == 2).ToList().Count != 0;
            ViewBag.CanDeleteRequest = account.Permissions.Where(p => p.PermissionId == 3).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ViewRequest = account.Permissions.Where(p => p.PermissionId == 5).ToList().Count != 0;
            ViewBag.ApprovalAllowed = account.Permissions.Where(p => p.PermissionId == 6).ToList().Count != 0;
            ViewBag.GetInWorkRequest = account.Permissions.Where(p => p.PermissionId == 7).ToList().Count != 0;

            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task<ActionResult> Index(string search = "",int equipmentType = 0, int page = 1, int branch = 0)
        {
            await PopulateAccountInfo();
            var equipments = await equipmentRepository.GetEquipments();
            EquipmentsListViewModel model = ModelFromData.GetListViewModel(equipments, search, equipmentType, page, pageSize);
            var types = await equipmentTypeRepository.GetEquipmentTypes();
            model.EquipmentTypes = new SelectList(types, "Id", "Name");
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            EquipmentViewModel model = new EquipmentViewModel();
            var types = await equipmentTypeRepository.GetEquipmentTypes();
            model.EquipmentTypes = new SelectList(types, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(EquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var equipment = DataFromModel.GetData(model);
                await equipmentRepository.Add(equipment);
                return RedirectToAction("Index", "Category", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var equipment = await equipmentLogic.GetEquipment(id);
            EquipmentViewModel model = ModelFromData.GetViewModel(equipment);
            var types = await equipmentTypeRepository.GetEquipmentTypes();
            model.EquipmentTypes = new SelectList(types, "Id", "Name", model.SelectedEquipmentType);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var equipment = DataFromModel.GetData(model);
                await equipmentRepository.Update(equipment);
                return RedirectToAction("Index", "Category", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var equipment = await equipmentLogic.GetEquipment(id);
            EquipmentViewModel model = ModelFromData.GetViewModel(equipment);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, EquipmentViewModel model)
        {
            var equipment = await equipmentLogic.GetEquipment(id);
            await equipmentRepository.Delete(equipment);
            return RedirectToAction("Index", "Category", new { Area = "ControlPanel" });
        }
    }
}