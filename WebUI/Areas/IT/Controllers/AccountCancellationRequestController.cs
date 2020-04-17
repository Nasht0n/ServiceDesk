using BusinessLogic.Abstract;
using BusinessLogic.Abstract.Branches.IT.Accounts.Attachments;
using BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles;
using BusinessLogic.Abstract.Branches.IT.Accounts.Requests;
using Domain.Models;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.Enum;
using WebUI.Models.Helpers;
using WebUI.ViewModels.Requests.IT.Accounts;

namespace WebUI.Areas.IT.Controllers
{
    public class AccountCancellationRequestController : Controller
    {
        private const int SERVICE_ID = 6;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IAccountCancellationRequestLogic requestLogic;
        private readonly IAccountCancellationRequestLifeCycleLogic lifeCycleLogic;
        private readonly IAttachmentLogic attachmentLogic;
        private readonly IAccountCancellationRequestAttachmentLogic requestAttachmentLogic;

        public AccountCancellationRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic,
            IPriorityLogic priorityLogic, IServiceLogic serviceLogic, ISubdivisionLogic subdivisionLogic, IAccountCancellationRequestLogic requestLogic,
            IAccountCancellationRequestLifeCycleLogic lifeCycleLogic,
            IAttachmentLogic attachmentLogic, IAccountCancellationRequestAttachmentLogic requestAttachmentLogic)
        {
            this.accountLogic = accountLogic;
            this.employeeLogic = employeeLogic;
            this.accountPermissionLogic = accountPermissionLogic;
            this.priorityLogic = priorityLogic;
            this.serviceLogic = serviceLogic;
            this.subdivisionLogic = subdivisionLogic;
            this.requestLogic = requestLogic;
            this.lifeCycleLogic = lifeCycleLogic;
            this.attachmentLogic = attachmentLogic;
            this.requestAttachmentLogic = requestAttachmentLogic;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = await accountLogic.GetAccountById(id);
            var user = await employeeLogic.GetEmployeeById(account.EmployeeId);
            account.Permissions = await accountPermissionLogic.GetPermissions(account.Id);
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        private async Task PopulateDropDownList(AccountCancellationRequestViewModel model)
        {
            var priorities = await priorityLogic.GetPriorities();
            model.Priorities = new SelectList(priorities, "Id", "Fullname");
        }

        private async Task<AccountCancellationRequest> InitializeRequest(AccountCancellationRequestViewModel model, Employee user)
        {
            AccountCancellationRequest request = new AccountCancellationRequest();
            Service service = await serviceLogic.GetServiceById(SERVICE_ID);
            request.ServiceId = service.Id;
            request.StatusId = (service.ApprovalRequired) ? (int)RequestStatus.Approval : (int)RequestStatus.Open;
            request.PriorityId = model.PriorityId;
            request.ClientId = user.Id;
            request.SubdivisionId = user.SubdivisionId;
            ExecutorGroup executorGroup = RequestHelper.GetExecutorGroup(service);
            request.ExecutorGroupId = executorGroup.Id;
            Employee executor = await RequestHelper.GetExecutor(user, executorGroup, subdivisionLogic, employeeLogic);
            request.ExecutorId = executor?.Id;
            request.Title = model.Title;
            request.Justification = model.Justification;
            request.Description = model.Description;
            return request;
        }

        private AccountCancellationRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            AccountCancellationRequestLifeCycle lifeCycle = new AccountCancellationRequestLifeCycle();
            lifeCycle.Date = DateTime.Now;
            lifeCycle.EmployeeId = user.Id;
            lifeCycle.Message = message;
            lifeCycle.RequestId = requestId;
            return lifeCycle;
        }

        private async Task ChangeRequestStatus(int id, RequestStatus status)
        {
            var request = await requestLogic.GetRequestById(id);
            request.StatusId = (int)status;
            await requestLogic.Save(request);
        }

        private async Task LifeCycleMessage(int id, Employee user, string msg)
        {
            var lifeCycle = InitializeLifeCycle(id, user, msg);
            await lifeCycleLogic.Add(lifeCycle);
        }

        public async Task<ActionResult> Details(int id)
        {
            Employee user = await PopulateAccountInfo();
            AccountCancellationRequest request = await requestLogic.GetRequestById(id);
            var service = await serviceLogic.GetServiceById(request.ServiceId);
            List<AccountCancellationRequestLifeCycle> lifeCycles = await lifeCycleLogic.GetLifeCycles(request.Id);
            AccountCancellationDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);
            model.AllApproval = IsApproval(service, lifeCycles);
            return View(model);
        }

        private bool IsApproval(Service service, List<AccountCancellationRequestLifeCycle> lifeCycles)
        {
            bool allApproval = true;
            if (service.ManyApprovalRequired)
            {
                foreach (var approver in service.Approvers)
                {
                    if (!allApproval) break;
                    var lifeCycle = lifeCycles.FirstOrDefault(l => l.EmployeeId == approver.EmployeeId && l.Message == "Заявка прошла согласование");
                    allApproval = lifeCycle != null ? true : false;
                }
            }
            return allApproval;
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            AccountCancellationRequestViewModel model = new AccountCancellationRequestViewModel();
            await PopulateDropDownList(model);
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AccountCancellationRequestViewModel model)
        {
            await PopulateDropDownList(model);
            Employee user = await PopulateAccountInfo();
            var request = await InitializeRequest(model, user);
            await requestLogic.Save(request);
            await LifeCycleMessage(request.Id, user, "Создание заявки");


            foreach (var file in model.Files)
            {
                string FileName = Path.GetFileNameWithoutExtension(file.FileName);
                string FileExtension = Path.GetExtension(file.FileName);
                string UploadPath = Server.MapPath("~/Files/UploadedFiles/");
                model.FilePath = UploadPath + DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                file.SaveAs(model.FilePath);
                Attachment attachmentFile = new Attachment
                {
                    DateUploaded = DateTime.Now,
                    Filename = FileName,
                    Path = UploadPath + FileName
                };
                attachmentFile = await attachmentLogic.Save(attachmentFile);
                AccountCancellationRequestAttachment attachment = new AccountCancellationRequestAttachment
                {
                    AttachmentId = attachmentFile.Id,
                    RequestId = request.Id
                };
                await requestAttachmentLogic.Add(attachment);
            }

            return RedirectToAction("Details", "AccountCancellationRequest", new { id = request.Id });
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            AccountCancellationRequestViewModel model = ModelFromData.GetViewModel(request);
            await PopulateDropDownList(model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AccountCancellationRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await PopulateDropDownList(model);
            var request = DataFromModel.GetData(model);
            var attachments = await requestAttachmentLogic.GetAttachments(request);
            foreach (var attachment in attachments)
            {
                var file = await attachmentLogic.GetAttachment(attachment.AttachmentId);
            }
            await requestLogic.Save(request);
            await LifeCycleMessage(request.Id, user, "Редактирование заявки");
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id = request.Id });
        }
    }
}