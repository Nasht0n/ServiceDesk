using Domain.Models;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using Domain.Models.Requests.Communication;
using Domain.Models.Requests.Email;
using Domain.Models.Requests.Equipment;
using Domain.Models.Requests.Network;
using Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using WebUI.ViewModels.AccountModel;
using WebUI.ViewModels.AttachmentsModel;
using WebUI.ViewModels.AttachmentsModel.IT.Accounts;
using WebUI.ViewModels.BranchModel;
using WebUI.ViewModels.CampusModel;
using WebUI.ViewModels.CategoryModel;
using WebUI.ViewModels.ComponentModel;
using WebUI.ViewModels.ConsumableModel;
using WebUI.ViewModels.EmployeeModel;
using WebUI.ViewModels.EquipmentModel;
using WebUI.ViewModels.EquipmentTypeModel;
using WebUI.ViewModels.ExecutorGroupMembers;
using WebUI.ViewModels.ExecutorGroupModel;
using WebUI.ViewModels.LifeCycles.IT.Accounts;
using WebUI.ViewModels.LifeCycles.IT.Communications;
using WebUI.ViewModels.LifeCycles.IT.Emails;
using WebUI.ViewModels.LifeCycles.IT.Equipments;
using WebUI.ViewModels.LifeCycles.IT.Networks;
using WebUI.ViewModels.PermissionModel;
using WebUI.ViewModels.PriorityModel;
using WebUI.ViewModels.Requests.IT.Accounts;
using WebUI.ViewModels.Requests.IT.Communications;
using WebUI.ViewModels.Requests.IT.Emails;
using WebUI.ViewModels.Requests.IT.Equipments;
using WebUI.ViewModels.Requests.IT.Networks;
using WebUI.ViewModels.Requests.View;
using WebUI.ViewModels.ServiceModel;
using WebUI.ViewModels.ServicesApproversModel;
using WebUI.ViewModels.ServicesExecutorGroupsModel;
using WebUI.ViewModels.StatusModel;
using WebUI.ViewModels.SubdivisionExecutorsModel;
using WebUI.ViewModels.SubdivisionModel;

namespace WebUI.Models
{
    public static class ModelFromData
    {
        public static SubdivisionViewModel GetViewModel(Subdivision subdivision)
        {
            return new SubdivisionViewModel
            {
                Id = subdivision.Id,
                Fullname = subdivision.Fullname,
                Shortname = subdivision.Shortname
            };
        }

        public static AccountViewModel GetViewModel(Account account)
        {
            AccountViewModel model = new AccountViewModel
            {
                Id = account.Id,
                Username = account.Username,
                Password = account.Password,
                IsEnabled = account.IsEnabled,
                RegistrationDate = account.DateRegistration,
                ChangePasswordDate = account.DateChangePassword,
                ChangePasswordOnNextEnter = account.ChangePasswordOnNextEnter,
                LastEnterDateTime = account.LastEnterDateTime,
                EmployeeModel = GetViewModel(account.Employee)
            };
            return model;
        }

        public static AccountViewModel GetViewModel(Account account, List<Permission> permissions)
        {
            AccountViewModel model = new AccountViewModel
            {
                Id = account.Id,
                Username = account.Username,
                Password = account.Password,
                IsEnabled = account.IsEnabled,
                RegistrationDate = account.DateRegistration,
                ChangePasswordDate = account.DateChangePassword,
                ChangePasswordOnNextEnter = account.ChangePasswordOnNextEnter,
                LastEnterDateTime = account.LastEnterDateTime,
                EmployeeModel = GetViewModel(account.Employee)
            };
            model.Permissions = new List<PermissionViewModel>();
            foreach (var permission in permissions)
            {
                model.Permissions.Add(new PermissionViewModel
                {
                    Id = permission.Id,
                    Title = permission.Title,
                    Description = permission.Description,
                    IsChecked = false
                });
            }
            return model;
        }

        public static ComponentsListViewModel GetListViewModel(List<Component> components, string search, int page, int pageSize)
        {
            ComponentsListViewModel model = new ComponentsListViewModel();
            List<ComponentViewModel> list = new List<ComponentViewModel>();

            if (!string.IsNullOrWhiteSpace(search))
            {
                list = list.Where(c => c.Name.Contains(search)).ToList();
                model.Search = search;
            }

            foreach (var component in components)
            {
                ComponentViewModel item = GetViewModel(component);
                list.Add(item);
            }

            if (page != 0 && pageSize != 0)
            {
                model.Components = list
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = list.Count()
                };

            }


            return model;
        }

        public static ServicesListViewModel GetListViewModel(List<Service> services, string search, int page, int branch, int category, int pageSize)
        {
            ServicesListViewModel model = new ServicesListViewModel();
            List<ServiceViewModel> list = new List<ServiceViewModel>();

            if (branch != 0)
            {
                services = services.Where(s => s.Category.BranchId == branch).ToList();
            }

            if (category != 0)
            {
                services = services.Where(s => s.CategoryId == category).ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                services = services.Where(s => s.Name.Contains(search)).ToList();
                model.Search = search;
            }

            foreach (var service in services)
            {
                ServiceViewModel item = GetViewModel(service);
                list.Add(item);
            }

            if (page != 0 && pageSize != 0)
            {
                model.Services = list
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = list.Count()
                };

            }


            return model;
        }

        public static VideoCommunicationDetailsRequestViewModel GetViewModel(VideoCommunicationRequest request, Employee user, List<VideoCommunicationRequestLifeCycle> lifeCycles)
        {
            VideoCommunicationDetailsRequestViewModel model = new VideoCommunicationDetailsRequestViewModel();
            model.RequestModel = new VideoCommunicationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                CampusId = request.CampusId,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision),
                Date = request.Date
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.LifeCyclesListModel = new List<VideoCommunicationRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new VideoCommunicationRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static VideoCommunicationRequestViewModel GetViewModel(VideoCommunicationRequest request)
        {
            VideoCommunicationRequestViewModel model = new VideoCommunicationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision),
                Date = request.Date
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static PhoneRepairDetailsRequestViewModel GetViewModel(PhoneRepairRequest request, Employee user, List<PhoneRepairRequestLifeCycle> lifeCycles)
        {
            PhoneRepairDetailsRequestViewModel model = new PhoneRepairDetailsRequestViewModel();
            model.RequestModel = new PhoneRepairRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                CampusId = request.CampusId,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.LifeCyclesListModel = new List<PhoneRepairRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new PhoneRepairRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static PhoneRepairRequestViewModel GetViewModel(PhoneRepairRequest request)
        {
            PhoneRepairRequestViewModel model = new PhoneRepairRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static PhoneNumberAllocationDetailsRequestViewModel GetViewModel(PhoneNumberAllocationRequest request, Employee user, List<PhoneNumberAllocationRequestLifeCycle> lifeCycles)
        {
            PhoneNumberAllocationDetailsRequestViewModel model = new PhoneNumberAllocationDetailsRequestViewModel();
            model.RequestModel = new PhoneNumberAllocationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                CampusId = request.CampusId,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.LifeCyclesListModel = new List<PhoneNumberAllocationRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new PhoneNumberAllocationRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static PhoneNumberAllocationRequestViewModel GetViewModel(PhoneNumberAllocationRequest request)
        {
            PhoneNumberAllocationRequestViewModel model = new PhoneNumberAllocationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static PhoneLineRepairDetailsRequestViewModel GetViewModel(PhoneLineRepairRequest request, Employee user, List<PhoneLineRepairRequestLifeCycle> lifeCycles)
        {
            PhoneLineRepairDetailsRequestViewModel model = new PhoneLineRepairDetailsRequestViewModel();
            model.RequestModel = new PhoneLineRepairRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                CampusId = request.CampusId,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.LifeCyclesListModel = new List<PhoneLineRepairRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new PhoneLineRepairRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static PhoneLineRepairRequestViewModel GetViewModel(PhoneLineRepairRequest request)
        {
            PhoneLineRepairRequestViewModel model = new PhoneLineRepairRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static HoldingPhoneLineDetailsRequestViewModel GetViewModel(HoldingPhoneLineRequest request, Employee user, List<HoldingPhoneLineRequestLifeCycle> lifeCycles)
        {
            HoldingPhoneLineDetailsRequestViewModel model = new HoldingPhoneLineDetailsRequestViewModel();
            model.RequestModel = new HoldingPhoneLineRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                CampusId = request.CampusId,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.LifeCyclesListModel = new List<HoldingPhoneLineRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new HoldingPhoneLineRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static HoldingPhoneLineRequestViewModel GetViewModel(HoldingPhoneLineRequest request)
        {
            HoldingPhoneLineRequestViewModel model = new HoldingPhoneLineRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static EmailSizeIncreaseDetailsRequestViewModel GetViewModel(EmailSizeIncreaseRequest request, Employee user, List<EmailSizeIncreaseRequestLifeCycle> lifeCycles)
        {
            EmailSizeIncreaseDetailsRequestViewModel model = new EmailSizeIncreaseDetailsRequestViewModel();
            model.RequestModel = new EmailSizeIncreaseRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                Email = request.Email,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.LifeCyclesListModel = new List<EmailSizeIncreaseRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new EmailSizeIncreaseRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static EmailSizeIncreaseRequestViewModel GetViewModel(EmailSizeIncreaseRequest request)
        {
            EmailSizeIncreaseRequestViewModel model = new EmailSizeIncreaseRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                Email = request.Email,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static EmailRegistrationDetailsRequestViewModel GetViewModel(EmailRegistrationRequest request, Employee user, List<EmailRegistrationRequestLifeCycle> lifeCycles)
        {
            EmailRegistrationDetailsRequestViewModel model = new EmailRegistrationDetailsRequestViewModel();
            model.RequestModel = new EmailRegistrationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                Email =request.Email,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }           

            model.LifeCyclesListModel = new List<EmailRegistrationRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new EmailRegistrationRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static EmailRegistrationRequestViewModel GetViewModel(EmailRegistrationRequest request)
        {
            EmailRegistrationRequestViewModel model = new EmailRegistrationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                Email = request.Email,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static AccountDisconnectDetailsRequestViewModel GetViewModel(AccountDisconnectRequest request, Employee user, List<AccountDisconnectRequestLifeCycle> lifeCycles)
        {
            AccountDisconnectDetailsRequestViewModel model = new AccountDisconnectDetailsRequestViewModel();
            model.RequestModel = new AccountDisconnectRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.AttachmentsListModel = new List<AccountDisconnectRequestAttachmentViewModel>();

            foreach (var attachment in request.Attachments)
            {
                AccountDisconnectRequestAttachmentViewModel item = new AccountDisconnectRequestAttachmentViewModel
                {
                    AttachmentModel = GetViewModel(attachment.Attachment)
                };
                model.AttachmentsListModel.Add(item);
            }

            model.LifeCyclesListModel = new List<AccountDisconnectRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new AccountDisconnectRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static NetworkConnectionRequestViewModel GetViewModel(NetworkConnectionRequest request)
        {
            NetworkConnectionRequestViewModel model = new NetworkConnectionRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }

            model.Connections = new List<ConnectionEquipmentViewModel>();
            foreach (var item in request.ConnectionEquipments)
            {
                model.Connections.Add(new ConnectionEquipmentViewModel
                {
                    Id = item.Id,
                    Count = item.Count,
                    EquipmentTypeId = item.EquipmentTypeId,
                    EquipmentTypeModel = GetViewModel(item.EquipmentType),
                    RequestId = item.RequestId
                });
            }
            return model;
        }

        public static NetworkConnectionDetailsRequestViewModel GetViewModel(NetworkConnectionRequest request, Employee user, List<NetworkConnectionRequestLifeCycle> lifeCycles)
        {
            NetworkConnectionDetailsRequestViewModel model = new NetworkConnectionDetailsRequestViewModel();
            model.RequestModel = new NetworkConnectionRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                Location = request.Location,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }
           
            model.RequestModel.Connections = new List<ConnectionEquipmentViewModel>();
            foreach (var item in request.ConnectionEquipments)
            {
                model.RequestModel.Connections.Add(new ConnectionEquipmentViewModel
                {
                    Id = item.Id,
                    Count = item.Count,
                    EquipmentTypeId = item.EquipmentTypeId,
                    EquipmentTypeModel = GetViewModel(item.EquipmentType),
                    RequestId = item.RequestId
                });
            }
            model.LifeCyclesListModel = new List<NetworkConnectionRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new NetworkConnectionRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static AccountDisconnectRequestViewModel GetViewModel(AccountDisconnectRequest request)
        {
            AccountDisconnectRequestViewModel model = new AccountDisconnectRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision),
                Title = request.Title
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId.Value;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static AccountLossDetailsRequestViewModel GetViewModel(AccountLossRequest request, Employee user, List<AccountLossRequestLifeCycle> lifeCycles)
        {
            AccountLossDetailsRequestViewModel model = new AccountLossDetailsRequestViewModel();
            model.RequestModel = new AccountLossRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.AttachmentsListModel = new List<AccountLossRequestAttachmentViewModel>();

            foreach (var attachment in request.Attachments)
            {
                AccountLossRequestAttachmentViewModel item = new AccountLossRequestAttachmentViewModel
                {
                    AttachmentModel = GetViewModel(attachment.Attachment)
                };
                model.AttachmentsListModel.Add(item);
            }

            model.LifeCyclesListModel = new List<AccountLossRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new AccountLossRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static AccountLossRequestViewModel GetViewModel(AccountLossRequest request)
        {
            AccountLossRequestViewModel model = new AccountLossRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision),
                Title = request.Title
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId.Value;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static AccountRegistrationDetailsRequestViewModel GetViewModel(AccountRegistrationRequest request, Employee user, List<AccountRegistrationRequestLifeCycle> lifeCycles)
        {
            AccountRegistrationDetailsRequestViewModel model = new AccountRegistrationDetailsRequestViewModel();
            model.RequestModel = new AccountRegistrationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.AttachmentsListModel = new List<AccountRegistrationRequestAttachmentViewModel>();

            foreach (var attachment in request.Attachments)
            {
                AccountRegistrationRequestAttachmentViewModel item = new AccountRegistrationRequestAttachmentViewModel
                {
                    AttachmentModel = GetViewModel(attachment.Attachment)
                };
                model.AttachmentsListModel.Add(item);
            }

            model.LifeCyclesListModel = new List<AccountRegistrationRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new AccountRegistrationRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static AccountRegistrationRequestViewModel GetViewModel(AccountRegistrationRequest request)
        {
            AccountRegistrationRequestViewModel model = new AccountRegistrationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision),
                Title = request.Title
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId.Value;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static AccountCancellationDetailsRequestViewModel GetViewModel(AccountCancellationRequest request, Employee user, List<AccountCancellationRequestLifeCycle> lifeCycles)
        {
            AccountCancellationDetailsRequestViewModel model = new AccountCancellationDetailsRequestViewModel();
            model.RequestModel = new AccountCancellationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }

            model.AttachmentsListModel = new List<AccountCancellationRequestAttachmentViewModel>();

            foreach(var attachment in request.Attachments)
            {
                AccountCancellationRequestAttachmentViewModel item = new AccountCancellationRequestAttachmentViewModel { 
                    AttachmentModel = GetViewModel(attachment.Attachment)                    
                };
                model.AttachmentsListModel.Add(item);
            }

            model.LifeCyclesListModel = new List<AccountCancellationRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new AccountCancellationRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static AccountCancellationRequestViewModel GetViewModel(AccountCancellationRequest request)
        {
            AccountCancellationRequestViewModel model = new AccountCancellationRequestViewModel
            {
                Id = request.Id,
                ClientId = request.ClientId,                
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision),
                Title = request.Title
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId.Value;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static AttachmentViewModel GetViewModel(Attachment attachment)
        {
            return new AttachmentViewModel { Id = attachment.Id, DateUploaded = attachment.DateUploaded, Filename = attachment.Filename, Path = attachment.Path };
        }

        public static ExecutorGroupsListViewModel GetListViewModel(List<ExecutorGroup> executorGroups, string search, int page, int pageSize)
        {
            ExecutorGroupsListViewModel model = new ExecutorGroupsListViewModel();
            List<ExecutorGroupViewModel> list = new List<ExecutorGroupViewModel>();

            if (!string.IsNullOrWhiteSpace(search))
            {
                executorGroups = executorGroups.Where(eg => eg.Name.Contains(search)).ToList();
                model.Search = search;
            }

            foreach (var executorGroup in executorGroups)
            {
                ExecutorGroupViewModel item = GetViewModel(executorGroup);
                list.Add(item);
            }

            if (page != 0 && pageSize != 0)
            {
                model.ExecutorGroups = list
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = list.Count()
                };
            }
            return model;
        }

        public static List<SubdivisionExecutorViewModel> GetViewModel(List<SubdivisionExecutor> executors)
        {
            List<SubdivisionExecutorViewModel> model = new List<SubdivisionExecutorViewModel>();
            foreach (var exec in executors)
            {
                model.Add(new SubdivisionExecutorViewModel
                {
                    ExecutorId = exec.EmployeeId,
                    ExecutorModel = GetViewModel(exec.Employee),
                    SubdivisionId = exec.SubdivisionId,
                    SubdivisionModel = GetViewModel(exec.Subdivision)
                });
            }
            return model;
        }

        public static List<PermissionViewModel> GetListViewModel(List<Permission> permissions)
        {
            List<PermissionViewModel> result = new List<PermissionViewModel>();
            foreach (var permission in permissions)
            {
                PermissionViewModel item = new PermissionViewModel
                {
                    Id = permission.Id,
                    Title = permission.Title,
                    Description = permission.Description,
                    IsChecked = false
                };
                result.Add(item);
            }
            return result;
        }

        public static List<ExecutorGroupMemberViewModel> GetViewModel(List<ExecutorGroupMember> executorGroupMembers)
        {
            List<ExecutorGroupMemberViewModel> model = new List<ExecutorGroupMemberViewModel>();
            foreach (var group in executorGroupMembers)
            {
                model.Add(new ExecutorGroupMemberViewModel
                {
                    EmployeeId = group.EmployeeId,
                    EmployeeModel = GetViewModel(group.Employee),
                    ExecutorGroupId = group.ExecutorGroupId,
                    ExecutorGroupModel = GetViewModel(group.ExecutorGroup)
                });
            }
            return model;
        }

        public static List<PermissionViewModel> GetListViewModel(List<Permission> permissions, List<AccountPermission> accountPermissions)
        {
            List<PermissionViewModel> result = new List<PermissionViewModel>();
            foreach (var permission in permissions)
            {
                PermissionViewModel item = new PermissionViewModel
                {
                    Id = permission.Id,
                    Title = permission.Title,
                    Description = permission.Description
                };
                var temp = accountPermissions.SingleOrDefault(ap => ap.PermissionId == permission.Id);
                item.IsChecked = temp != null ? true : false;
                result.Add(item);
            }
            return result;
        }



        public static RequestListViewModel GetListViewModel(List<Requests> requests, Employee user, int service)
        {
            RequestListViewModel model = new RequestListViewModel();
            List<RequestViewModel> requestsModel = new List<RequestViewModel>();
            foreach (var request in requests)
            {
                RequestViewModel item = GetViewModel(request);
                requestsModel.Add(item);
            }
            model.Requests = requestsModel;
            model.CurrentService = service;
            return model;
        }

        public static List<ServicesExecutorGroupsViewModel> GetViewModel(List<ServicesExecutorGroup> serviceExecutorGroups)
        {
            List<ServicesExecutorGroupsViewModel> model = new List<ServicesExecutorGroupsViewModel>();

            foreach (var service in serviceExecutorGroups)
            {
                model.Add(new ServicesExecutorGroupsViewModel
                {
                    ServiceId = service.ServiceId,
                    ExecutorGroupId = service.ExecutorGroupId,
                    ExecutorGroupModel = GetViewModel(service.ExecutorGroup),
                    ServiceModel = GetViewModel(service.Service)
                });
            }

            return model;
        }

        public static RequestViewModel GetViewModel(Requests request)
        {
            RequestViewModel model = new RequestViewModel
            {
                RequestId = request.RequestId,
                ClientId = request.ClientId,
                ClientModel = GetViewModel(request.Client),
                Date = request.Date,
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                Source = request.Source,
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision),
                Title = request.Title
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId.Value;
                model.ExecutorModel = GetViewModel(request.Executor);
            }
            return model;
        }

        public static List<ServicesApproversViewModel> GetViewModel(List<ServicesApprover> serviceApprovers)
        {
            List<ServicesApproversViewModel> model = new List<ServicesApproversViewModel>();

            foreach (var service in serviceApprovers)
            {
                model.Add(new ServicesApproversViewModel
                {
                    EmployeeId = service.EmployeeId,
                    ServiceId = service.ServiceId,
                    EmployeeModel = GetViewModel(service.Employee),
                    ServiceModel = GetViewModel(service.Service)
                });
            }

            return model;
        }

        public static EquipmentReplaceDetailsRequestViewModel GetViewModel(EquipmentReplaceRequest request, Employee user, List<EquipmentReplaceRequestLifeCycle> lifeCycles)
        {
            EquipmentReplaceDetailsRequestViewModel model = new EquipmentReplaceDetailsRequestViewModel();
            model.RequestModel = new EquipmentReplaceRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }
            model.RequestModel.Replaces = new List<ReplaceEquipmentViewModel>();
            foreach (var item in request.ReplaceEquipments)
            {
                model.RequestModel.Replaces.Add(new ReplaceEquipmentViewModel
                {
                    Id = item.Id,
                    InventoryNumber = item.InventoryNumber,
                    EquipmentTypeId = item.EquipmentTypeId,
                    RequestId = item.RequestId,
                    EquipmentTypeModel = GetViewModel(item.EquipmentType)
                });
            }
            model.LifeCyclesListModel = new List<EquipmentReplaceRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new EquipmentReplaceRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static ComponentReplaceRequestViewModel GetViewModel(ComponentReplaceRequest request)
        {
            ComponentReplaceRequestViewModel model = new ComponentReplaceRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }

            model.Replaces = new List<ReplaceComponentViewModel>();
            foreach (var item in request.ReplaceComponents)
            {
                model.Replaces.Add(new ReplaceComponentViewModel
                {
                    Id = item.Id,
                    Count = item.Count,
                    ComponentModel = GetViewModel(item.Component),
                    RequestId = item.RequestId

                });
            }
            return model;
        }

        public static ComponentReplaceDetailsRequestViewModel GetViewModel(ComponentReplaceRequest request, Employee user, List<ComponentReplaceRequestLifeCycle> lifeCycles)
        {
            ComponentReplaceDetailsRequestViewModel model = new ComponentReplaceDetailsRequestViewModel();
            model.RequestModel = new ComponentReplaceRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }
            model.RequestModel.Replaces = new List<ReplaceComponentViewModel>();
            foreach (var item in request.ReplaceComponents)
            {
                model.RequestModel.Replaces.Add(new ReplaceComponentViewModel
                {
                    Id = item.Id,
                    Count = item.Count,
                    ComponentId = item.ComponentId,
                    RequestId = item.RequestId,
                    ComponentModel = GetViewModel(item.Component)
                });
            }
            model.LifeCyclesListModel = new List<ComponentReplaceRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new ComponentReplaceRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static ComponentViewModel GetViewModel(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                Name = component.Name
            };
        }

        public static EquipmentRefillRequestViewModel GetViewModel(EquipmentRefillRequest request)
        {
            EquipmentRefillRequestViewModel model = new EquipmentRefillRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }

            model.Refills = new List<RefillEquipmentViewModel>();
            foreach (var item in request.RefillEquipments)
            {
                model.Refills.Add(new RefillEquipmentViewModel
                {
                    Id = item.Id,
                    InventoryNumber = item.InventoryNumber,
                    RequestId = item.RequestId
                });
            }
            return model;
        }

        public static EquipmentRefillDetailsRequestViewModel GetViewModel(EquipmentRefillRequest request, Employee user, List<EquipmentRefillRequestLifeCycle> lifeCycles)
        {
            EquipmentRefillDetailsRequestViewModel model = new EquipmentRefillDetailsRequestViewModel();
            model.RequestModel = new EquipmentRefillRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }
            model.RequestModel.Refills = new List<RefillEquipmentViewModel>();
            foreach (var item in request.RefillEquipments)
            {
                model.RequestModel.Refills.Add(new RefillEquipmentViewModel
                {
                    Id = item.Id,
                    InventoryNumber = item.InventoryNumber,
                    RequestId = item.RequestId
                });
            }
            model.LifeCyclesListModel = new List<EquipmentRefillRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new EquipmentRefillRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static EquipmentRepairRequestViewModel GetViewModel(EquipmentRepairRequest request)
        {
            EquipmentRepairRequestViewModel model = new EquipmentRepairRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision),
                InventoryNumber = request.InventoryNumber
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }
            return model;
        }

        public static EquipmentRepairDetailsRequestViewModel GetViewModel(EquipmentRepairRequest request, Employee user, List<EquipmentRepairRequestLifeCycle> lifeCycles)
        {
            EquipmentRepairDetailsRequestViewModel model = new EquipmentRepairDetailsRequestViewModel();
            model.RequestModel = new EquipmentRepairRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }
            model.Repairs = new List<RepairEquipmentViewModel>();
            foreach (var item in request.RepairEquipments)
            {
                model.Repairs.Add(new RepairEquipmentViewModel
                {
                    Id = item.Id,
                    Count = item.Count,
                    ConsumableId = item.ConsumableId,
                    RequestId = item.RequestId,
                    ConsumableModel = GetViewModel(item.Consumable)
                });
            }
            model.LifeCyclesListModel = new List<EquipmentRepairRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new EquipmentRepairRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }
            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static EquipmentReplaceRequestViewModel GetViewModel(EquipmentReplaceRequest request)
        {
            EquipmentReplaceRequestViewModel model = new EquipmentReplaceRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }

            model.Replaces = new List<ReplaceEquipmentViewModel>();
            foreach (var item in request.ReplaceEquipments)
            {
                model.Replaces.Add(new ReplaceEquipmentViewModel
                {
                    Id = item.Id,
                    InventoryNumber = item.InventoryNumber,
                    EquipmentTypeId = item.EquipmentTypeId,
                    RequestId = item.RequestId,
                    EquipmentTypeModel = GetViewModel(item.EquipmentType)
                });
            }
            return model;
        }

        public static SubdivisionsListViewModel GetListViewModel(List<Subdivision> subdivisions, string search, int page, int pageSize)
        {
            SubdivisionsListViewModel model = new SubdivisionsListViewModel();
            List<SubdivisionViewModel> subdivisionModels = new List<SubdivisionViewModel>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                subdivisions = subdivisions.Where(s => s.Fullname.Contains(search) || s.Shortname.Equals(search)).ToList();
            }

            foreach (var subdivision in subdivisions)
            {
                SubdivisionViewModel item = GetViewModel(subdivision);
                subdivisionModels.Add(item);
            }
            model.Subdivisions = subdivisionModels
                .OrderBy(s => s.Fullname)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = subdivisionModels.Count()
            };
            model.Search = search;
            return model;
        }

        public static EquipmentInstallationDetailsRequestViewModel GetViewModel(EquipmentInstallationRequest request, Employee user, List<EquipmentInstallationRequestLifeCycle> lifeCycles)
        {
            EquipmentInstallationDetailsRequestViewModel model = new EquipmentInstallationDetailsRequestViewModel();
            model.RequestModel = new EquipmentInstallationRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Title = request.Title,
                Justification = request.Justification,
                Description = request.Description,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            model.RequestModel.ExecutorId = request.ExecutorId ?? null;
            if (request.ExecutorId.HasValue)
            {
                model.RequestModel.Executor = GetViewModel(request.Executor);
            }
            model.RequestModel.Installations = new List<InstallationEquipmentViewModel>();
            foreach (var item in request.InstallationEquipments)
            {
                model.RequestModel.Installations.Add(new InstallationEquipmentViewModel
                {
                    Id = item.Id,
                    Count = item.Count,
                    EquipmentTypeId = item.EquipmentTypeId,
                    RequestId = item.RequestId,
                    EquipmentTypeModel = GetViewModel(item.EquipmentType)
                });
            }
            model.LifeCyclesListModel = new List<EquipmentInstallationRequestLifeCycleViewModel>();
            foreach (var record in lifeCycles)
            {
                model.LifeCyclesListModel.Add(new EquipmentInstallationRequestLifeCycleViewModel
                {
                    Id = record.Id,
                    Date = record.Date,
                    EmployeeId = record.EmployeeId,
                    Employee = GetViewModel(record.Employee),
                    Message = record.Message,
                    RequestId = record.RequestId
                });
            }

            model.IsApprovers = (user.ApprovalServices != null && user.ApprovalServices.Count > 0) ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue && user.Id == request.ExecutorId ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
            return model;
        }

        public static EquipmentInstallationRequestViewModel GetViewModel(EquipmentInstallationRequest request)
        {
            EquipmentInstallationRequestViewModel model = new EquipmentInstallationRequestViewModel
            {
                Id = request.Id,
                CampusId = request.CampusId,
                CampusModel = GetViewModel(request.Campus),
                ClientId = request.ClientId,
                Client = GetViewModel(request.Client),
                Description = request.Description,
                ExecutorGroupId = request.ExecutorGroupId,
                ExecutorGroupModel = GetViewModel(request.ExecutorGroup),
                Justification = request.Justification,
                Location = request.Location,
                PriorityId = request.PriorityId,
                PriorityModel = GetViewModel(request.Priority),
                ServiceId = request.ServiceId,
                ServiceModel = GetViewModel(request.Service),
                StatusId = request.StatusId,
                StatusModel = GetViewModel(request.Status),
                Title = request.Title,
                SubdivisionId = request.SubdivisionId,
                SubdivisionModel = GetViewModel(request.Subdivision)
            };
            if (request.ExecutorId.HasValue)
            {
                model.ExecutorId = request.ExecutorId;
                model.Executor = GetViewModel(request.Executor);
            }

            model.Installations = new List<InstallationEquipmentViewModel>();
            foreach (var item in request.InstallationEquipments)
            {
                model.Installations.Add(new InstallationEquipmentViewModel
                {
                    Id = item.Id,
                    Count = item.Count,
                    EquipmentTypeId = item.EquipmentTypeId,
                    RequestId = item.RequestId,
                    EquipmentTypeModel = GetViewModel(item.EquipmentType)
                });
            }
            return model;
        }

        public static StatusViewModel GetViewModel(Status status)
        {
            return new StatusViewModel
            {
                Id = status.Id,
                Fullname = status.Fullname,
                Shortname = status.Shortname
            };
        }

        public static PriorityViewModel GetViewModel(Priority priority)
        {
            return new PriorityViewModel
            {
                Id = priority.Id,
                Fullname = priority.Fullname,
                Shortname = priority.Shortname
            };
        }

        public static ExecutorGroupViewModel GetViewModel(ExecutorGroup executorGroup)
        {
            return new ExecutorGroupViewModel
            {
                Id = executorGroup.Id,
                Name = executorGroup.Name
            };
        }

        public static EquipmentViewModel GetViewModel(Equipment equipment)
        {
            return new EquipmentViewModel
            {
                Id = equipment.Id,
                Name = equipment.Name,
                InventoryNumber = equipment.InventoryNumber,
                EquipmentTypeModel = GetViewModel(equipment.EquipmentType)
            };
        }

        public static EquipmentsListViewModel GetListViewModel(List<Equipment> equipments, string search, int equipmentType, int page, int pageSize)
        {
            EquipmentsListViewModel model = new EquipmentsListViewModel();
            List<EquipmentViewModel> equipmentModels = new List<EquipmentViewModel>();
            if (equipmentType != 0)
            {
                equipments = equipments.Where(e => e.EquipmentTypeId == equipmentType).ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                equipments = equipments.Where(e => e.Name.Contains(search) || (e.InventoryNumber.Contains(search))).ToList();
            }

            foreach (var equipment in equipments)
            {
                EquipmentViewModel item = GetViewModel(equipment);
                equipmentModels.Add(item);
            }
            model.Equipments = equipmentModels
                .OrderBy(s => s.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = equipmentModels.Count()
            };
            model.Search = search;
            model.SelectedEquipmentType = equipmentType;
            return model;
        }

        public static EquipmentTypeViewModel GetViewModel(EquipmentType equipmentType)
        {
            return new EquipmentTypeViewModel
            {
                Id = equipmentType.Id,
                Name = equipmentType.Name
            };
        }

        public static EquipmentTypesListViewModel GetListViewModel(List<EquipmentType> equipmentTypes, string search, int page, int pageSize)
        {
            EquipmentTypesListViewModel model = new EquipmentTypesListViewModel();
            List<EquipmentTypeViewModel> equipmentTypeModels = new List<EquipmentTypeViewModel>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                equipmentTypes = equipmentTypes.Where(e => e.Name.Contains(search)).ToList();
            }

            foreach (var type in equipmentTypes)
            {
                EquipmentTypeViewModel item = GetViewModel(type);
                equipmentTypeModels.Add(item);
            }
            model.EquipmentTypes = equipmentTypeModels
                .OrderBy(s => s.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = equipmentTypeModels.Count()
            };
            model.Search = search;
            return model;
        }

        public static CampusViewModel GetViewModel(Campus campus)
        {
            return new CampusViewModel
            {
                Id = campus.Id,
                Name = campus.Name
            };
        }

        public static CampusesListViewModel GetListViewModel(List<Campus> campuses, string search, int page, int pageSize)
        {
            CampusesListViewModel model = new CampusesListViewModel();
            List<CampusViewModel> campusModels = new List<CampusViewModel>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                campuses = campuses.Where(c => c.Name.Contains(search)).ToList();
            }

            foreach (var campus in campuses)
            {
                CampusViewModel item = GetViewModel(campus);
                campusModels.Add(item);
            }
            model.Campuses = campusModels
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = campusModels.Count()
            };
            model.Search = search;
            return model;
        }

        public static EmployeeViewModel GetViewModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Firstname = employee.Firstname,
                Patronymic = employee.Patronymic,
                Post = employee.Post,
                Email = employee.Email,
                Phone = employee.Phone,
                HeadOfUnit = employee.HeadOfUnit,
                SelectedSubdivision = employee.SubdivisionId,
                SubdivisionModel = GetViewModel(employee.Subdivision),
            };
        }

        public static EmployeesListViewModel GetListViewModel(List<Employee> employees, string search = "", int subdivision = 0, int page = 0, int pageSize = 0)
        {
            EmployeesListViewModel model = new EmployeesListViewModel();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            if (subdivision != 0)
            {
                employees = employees.Where(e => e.SubdivisionId == subdivision).ToList();
                model.SelectedSubdivision = subdivision;
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                employees = employees.Where(e => e.Surname.Contains(search)).ToList();
                model.Search = search;
            }

            foreach (var employee in employees)
            {
                EmployeeViewModel item = GetViewModel(employee);
                employeeViewModels.Add(item);
            }

            if (page != 0 && pageSize != 0)
            {
                model.Employees = employeeViewModels
                .OrderBy(s => s.Surname)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = employeeViewModels.Count()
                };
            }
            return model;
        }

        public static BranchViewModel GetViewModel(Branch branch)
        {
            return new BranchViewModel
            {
                Id = branch.Id,
                Fullname = branch.Fullname,
                AreaName = branch.AreaName
            };
        }

        public static BranchesListViewModel GetListViewModel(List<Branch> branches, string search = "", int page = 0, int pageSize = 0)
        {
            BranchesListViewModel model = new BranchesListViewModel();
            List<BranchViewModel> branchModels = new List<BranchViewModel>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                branches = branches.Where(c => c.Fullname.Contains(search)).ToList();
            }

            foreach (var branch in branches)
            {
                BranchViewModel item = GetViewModel(branch);
                branchModels.Add(item);
            }

            if (page != 0 && pageSize != 0)
            {
                model.Branches = branchModels
                                .OrderBy(c => c.Fullname)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize).ToList();
                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = branchModels.Count()
                };
                model.Search = search;
            }
            else
            {
                model.Branches = branchModels;
            }

            return model;
        }

        public static CategoryViewModel GetViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                SelectedBranch = category.BranchId,
                BranchModel = GetViewModel(category.Branch)
            };
        }

        public static CategoriesListViewModel GetListViewModel(List<Category> categories, string search = "", int branch = 0, int page = 0, int pageSize = 0)
        {
            CategoriesListViewModel model = new CategoriesListViewModel();
            List<CategoryViewModel> categoryModels = new List<CategoryViewModel>();
            if (branch != 0)
            {
                categories = categories.Where(e => e.BranchId == branch).ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                categories = categories.Where(e => e.Name.Contains(search)).ToList();
            }

            foreach (var category in categories)
            {
                CategoryViewModel item = GetViewModel(category);
                categoryModels.Add(item);
            }
            if (page != 0 && pageSize != 0)
            {
                model.Categories = categoryModels
                    .OrderBy(s => s.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize).ToList();

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = categoryModels.Count()
                };
                model.Search = search;
                model.SelectedBranch = branch;
            }
            else
            {
                model.Categories = categoryModels;
            }
            return model;
        }

        public static ServiceViewModel GetViewModel(Service service)
        {
            return new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Visible = service.Visible,
                ApprovalRequired = service.ApprovalRequired,
                Controller = service.Controller,
                SelectedCategory = service.CategoryId,
                CategoryModel = GetViewModel(service.Category),
                BranchModel = GetViewModel(service.Category.Branch),
                SelectedBranch = service.Category.BranchId
            };
        }

        public static ServicesListViewModel GetListViewModel(List<Service> services, Category categoryModel, string search = "", int category = 0, int branch = 0, int page = 0, int pageSize = 0)
        {
            ServicesListViewModel model = new ServicesListViewModel();
            List<ServiceViewModel> serviceModels = new List<ServiceViewModel>();

            services = services.Where(c => c.CategoryId == categoryModel.Id).ToList();

            if (branch != 0)
            {
                services = services.Where(e => e.Category.BranchId == branch).ToList();
            }

            if (category != 0)
            {
                services = services.Where(e => e.CategoryId == category).ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                services = services.Where(e => e.Name.Contains(search)).ToList();
            }

            foreach (var service in services)
            {
                ServiceViewModel item = GetViewModel(service);
                serviceModels.Add(item);
            }

            if (page != 0 && pageSize != 0)
            {
                model.Services = serviceModels
                     .OrderBy(s => s.Name)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize).ToList();

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = serviceModels.Count()
                };
                model.Search = search;
                model.SelectedCategory = category;
            }
            else
            {
                model.Services = serviceModels;
            }
            model.SelectedBranch = categoryModel.BranchId;
            model.SelectedCategory = categoryModel.Id;

            model.CategoryModel = GetViewModel(categoryModel);

            return model;
        }

        public static ConsumableViewModel GetViewModel(Consumable consumable)
        {
            return new ConsumableViewModel
            {
                Id = consumable.Id,
                Name = consumable.Name
            };
        }

        public static ConsumablesListViewModel GetListViewModel(List<Consumable> consumables, string search, int page, int pageSize)
        {
            ConsumablesListViewModel model = new ConsumablesListViewModel();
            List<ConsumableViewModel> consumableModels = new List<ConsumableViewModel>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                consumables = consumables.Where(c => c.Name.Contains(search)).ToList();
            }

            foreach (var consumable in consumables)
            {
                ConsumableViewModel item = GetViewModel(consumable);
                consumableModels.Add(item);
            }
            model.Consumables = consumableModels
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = consumableModels.Count()
            };
            model.Search = search;
            return model;
        }
    }
}