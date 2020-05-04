using BusinessLogic.Abstract;
using BusinessLogic.Abstract.Branches.IT.Softwares.Attachments;
using BusinessLogic.Abstract.Branches.IT.Softwares.LifeCycles;
using BusinessLogic.Abstract.Branches.IT.Softwares.Requests;
using Domain.Models;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Software;
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
using WebUI.ViewModels.AttachmentsModel;
using WebUI.ViewModels.AttachmentsModel.IT.Softwares;
using WebUI.ViewModels.Requests.IT.Softwares;

namespace WebUI.Areas.IT.Controllers
{
    public class SoftwareReworkRequestController : Controller
    {
        private const int SERVICE_ID = 19;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly ISoftwareReworkRequestLogic requestLogic;
        private readonly ISoftwareReworkRequestLifeCycleLogic lifeCycleLogic;
        private readonly IAttachmentLogic attachmentLogic;
        private readonly ISoftwareReworkRequestAttachmentLogic requestAttachmentLogic;

        public SoftwareReworkRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic,
            IPriorityLogic priorityLogic, IServiceLogic serviceLogic, ISubdivisionLogic subdivisionLogic, ISoftwareReworkRequestLogic requestLogic,
            ISoftwareReworkRequestLifeCycleLogic lifeCycleLogic,
            IAttachmentLogic attachmentLogic, ISoftwareReworkRequestAttachmentLogic requestAttachmentLogic)
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

        private async Task PopulateDropDownList(SoftwareReworkRequestViewModel model)
        {
            var priorities = await priorityLogic.GetPriorities();
            model.Priorities = new SelectList(priorities, "Id", "Fullname");
        }

        private async Task<SoftwareReworkRequest> InitializeRequest(SoftwareReworkRequestViewModel model, Employee user)
        {
            SoftwareReworkRequest request = new SoftwareReworkRequest();
            Service service = await serviceLogic.GetService(SERVICE_ID);
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

        private SoftwareReworkRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            SoftwareReworkRequestLifeCycle lifeCycle = new SoftwareReworkRequestLifeCycle();
            lifeCycle.Date = DateTime.Now;
            lifeCycle.EmployeeId = user.Id;
            lifeCycle.Message = message;
            lifeCycle.RequestId = requestId;
            return lifeCycle;
        }

        private async Task ChangeRequestStatus(int id, RequestStatus status)
        {
            var request = await requestLogic.GetRequest(id);
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
            SoftwareReworkRequest request = await requestLogic.GetRequest(id);
            var service = await serviceLogic.GetService(request.ServiceId);
            List<SoftwareReworkRequestLifeCycle> lifeCycles = await lifeCycleLogic.GetLifeCycles(request);
            SoftwareReworkDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);
            model.AllApproval = IsApproval(service, lifeCycles);
            return View(model);
        }

        private bool IsApproval(Service service, List<SoftwareReworkRequestLifeCycle> lifeCycles)
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
            SoftwareReworkRequestViewModel model = new SoftwareReworkRequestViewModel();
            await PopulateDropDownList(model);
            var service = await serviceLogic.GetService(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(SoftwareReworkRequestViewModel model)
        {
            await PopulateDropDownList(model);
            Employee user = await PopulateAccountInfo();
            var request = await InitializeRequest(model, user);
            var service = await serviceLogic.GetService(SERVICE_ID);
            foreach (var file in model.Files)
            {
                string FileName = Path.GetFileNameWithoutExtension(file.FileName);
                string FileExtension = Path.GetExtension(file.FileName);
                string UploadPath = Server.MapPath("~/Files/UploadedFiles/SoftwareAttachments/");
                var filePath = UploadPath + FileName.Trim() + FileExtension;
                model.FilePath = filePath;
                file.SaveAs(model.FilePath);
                Attachment attachmentFile = new Attachment
                {
                    DateUploaded = DateTime.Now,
                    Filename = FileName,
                    Path = filePath
                };
                attachmentFile = await attachmentLogic.Save(attachmentFile);
                SoftwareReworkRequestAttachment attachment = new SoftwareReworkRequestAttachment
                {
                    AttachmentId = attachmentFile.Id
                };
                request.Attachments.Add(attachment);
            }
            await requestLogic.Save(request);
            await LifeCycleMessage(request.Id, user, "Создание заявки");
            return RedirectToAction("Details", service.Controller, new { id = request.Id });
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequest(id);
            SoftwareReworkRequestViewModel model = ModelFromData.GetViewModel(request);
            var attachments = await requestAttachmentLogic.GetAttachments(request);
            foreach (var attachment in attachments)
            {
                Attachment file = await attachmentLogic.GetAttachment(attachment.AttachmentId);
                AttachmentViewModel attachmentModel = ModelFromData.GetViewModel(file);
                model.AttachmentsModel.Add(new SoftwareReworkRequestAttachmentViewModel { AttachmentModel = attachmentModel });
            }
            await PopulateDropDownList(model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SoftwareReworkRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await PopulateDropDownList(model);
            var request = DataFromModel.GetData(model);
            var service = await serviceLogic.GetService(SERVICE_ID);
            foreach (var file in model.Files)
            {
                string FileName = Path.GetFileNameWithoutExtension(file.FileName);
                string FileExtension = Path.GetExtension(file.FileName);
                string UploadPath = Server.MapPath("~/Files/UploadedFiles/SoftwareAttachments/");
                var filePath = UploadPath + FileName.Trim() + FileExtension;
                model.FilePath = filePath;
                file.SaveAs(filePath);
                Attachment attachmentFile = new Attachment
                {
                    DateUploaded = DateTime.Now,
                    Filename = FileName,
                    Path = filePath
                };
                attachmentFile = await attachmentLogic.Save(attachmentFile);
                SoftwareReworkRequestAttachment attachment = new SoftwareReworkRequestAttachment
                {
                    AttachmentId = attachmentFile.Id,
                    RequestId = request.Id
                };
                await requestAttachmentLogic.Add(attachment);
            }

            await requestLogic.Save(request);
            await LifeCycleMessage(request.Id, user, "Редактирование заявки");
            return RedirectToAction("Details", service.Controller, new { id = request.Id });
        }

        public async Task<ActionResult> DeleteFile(int requestId, int attachmentId)
        {
            var service = await serviceLogic.GetService(SERVICE_ID);
            var attachment = await attachmentLogic.GetAttachment(attachmentId);
            await attachmentLogic.Delete(attachment);
            return RedirectToAction("Details", service.Controller, new { id = requestId });
        }

        public async Task<FileResult> DownloadFile(int attachmentId)
        {
            if (!string.IsNullOrWhiteSpace(User.Identity.Name))
            {
                var file = await attachmentLogic.GetAttachment(attachmentId);
                string filename = file.Filename + Path.GetExtension(file.Path);
                string content_type = MimeMapping.GetMimeMapping(filename);
                string file_type = content_type;
                return File(file.Path, file_type, filename);
            }
            else
            {
                return null;
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequest(id);
            SoftwareReworkRequestViewModel model = ModelFromData.GetViewModel(request);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, SoftwareReworkRequestViewModel model)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequest(id);
            await requestLogic.Delete(request);
            return RedirectToAction("Requests", "Dashboard", new { Area = "" });
        }

        public async Task<ActionResult> AgreeRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Open);
            await LifeCycleMessage(id, user, "Заявка прошла согласование");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> RejectRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Closed);
            await LifeCycleMessage(id, user, "Заявка не прошла согласование");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> GetInWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.InWork);
            await LifeCycleMessage(id, user, "Начало исполнения заявки");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> DoneWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Done);
            await LifeCycleMessage(id, user, "Заявка выполнена");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> Archive(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Archive);
            await LifeCycleMessage(id, user, "Заявка перенесена в архив");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> AddMessage(int id, SoftwareDevelopmentDetailsRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await LifeCycleMessage(id, user, model.Message);
            return RedirectToAction("Details", service.Controller, new { id });
        }
    }
}