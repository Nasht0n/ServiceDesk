using Domain.Models;
using Domain.Models.Requests.Accounts;
using Domain.Models.Requests.Communication;
using Domain.Models.Requests.Email;
using Domain.Models.Requests.Equipment;
using Domain.Models.Requests.Events;
using Domain.Models.Requests.Network;
using Domain.Models.Requests.Software;
using System;
using WebUI.ViewModels.AccountModel;
using WebUI.ViewModels.BranchModel;
using WebUI.ViewModels.CampusModel;
using WebUI.ViewModels.CategoryModel;
using WebUI.ViewModels.ComponentModel;
using WebUI.ViewModels.ConsumableModel;
using WebUI.ViewModels.EmployeeModel;
using WebUI.ViewModels.EquipmentModel;
using WebUI.ViewModels.EquipmentTypeModel;
using WebUI.ViewModels.ExecutorGroupModel;
using WebUI.ViewModels.PermissionModel;
using WebUI.ViewModels.Requests.IT.Accounts;
using WebUI.ViewModels.Requests.IT.Communications;
using WebUI.ViewModels.Requests.IT.Emails;
using WebUI.ViewModels.Requests.IT.Equipments;
using WebUI.ViewModels.Requests.IT.Events;
using WebUI.ViewModels.Requests.IT.Networks;
using WebUI.ViewModels.Requests.IT.Softwares;
using WebUI.ViewModels.ServiceModel;
using WebUI.ViewModels.SubdivisionModel;

namespace WebUI.Models
{
    public class DataFromModel
    {
        public static Subdivision GetData(SubdivisionViewModel model)
        {
            return new Subdivision
            {
                Id = model.Id,
                Fullname = model.Fullname,
                Shortname = model.Shortname
            };
        }

        public static Employee GetData(EmployeeViewModel model)
        {
            return new Employee
            {
                Id = model.Id,
                Surname = model.Surname,
                Firstname = model.Firstname,
                Patronymic = model.Patronymic,
                Post = model.Post,
                Email = model.Email,
                Phone = model.Phone,
                HeadOfUnit = model.HeadOfUnit,
                SubdivisionId = model.SelectedSubdivision.Value
            };
        }

        public static Campus GetData(CampusViewModel model)
        {
            return new Campus
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static Equipment GetData(EquipmentViewModel model)
        {
            return new Equipment
            {
                Id = model.Id,
                Name = model.Name,
                InventoryNumber = model.InventoryNumber,
                EquipmentTypeId = model.EquipmentTypeModel.Id
            };
        }

        public static EquipmentType GetData(EquipmentTypeViewModel model)
        {
            return new EquipmentType
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static Branch GetData(BranchViewModel model)
        {
            return new Branch
            {
                Id = model.Id,
                Fullname = model.Fullname,
                AreaName = model.AreaName
            };
        }

        public static Category GetData(CategoryViewModel model)
        {
            return new Category
            {
                Id = model.Id,
                Name = model.Name,
                BranchId = model.SelectedBranch.Value
            };
        }

        public static Service GetData(ServiceViewModel model)
        {
            return new Service
            {
                Id = model.Id,
                Name = model.Name,
                Visible = model.Visible,
                ApprovalRequired = model.ApprovalRequired,
                Controller = model.Controller,
                CategoryId = model.SelectedCategory.Value
            };
        }

        public static Component GetData(ComponentViewModel model)
        {
            return new Component
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static ExecutorGroup GetData(ExecutorGroupViewModel model)
        {
            return new ExecutorGroup
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static Account GetData(AccountViewModel model)
        {
            Account account = new Account
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                DateRegistration = model.RegistrationDate,
                DateChangePassword = model.ChangePasswordDate,
                LastEnterDateTime = model.LastEnterDateTime,
                IsEnabled = model.IsEnabled,
                ChangePasswordOnNextEnter = model.ChangePasswordOnNextEnter,
                EmployeeId = model.EmployeeModel.Id
            };

            return account;
        }

        public static Consumable GetData(ConsumableViewModel model)
        {
            return new Consumable
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static Permission GetData(PermissionViewModel permission)
        {
            return new Permission { Id = permission.Id, Description = permission.Description, Title = permission.Title };
        }

        public static InstallationEquipments GetData(InstallationEquipmentViewModel item)
        {
            return new InstallationEquipments
            {
                Id = item.Id,
                Count = item.Count,
                EquipmentTypeId = item.EquipmentTypeId,
                RequestId = item.RequestId
            };
        }

        public static EquipmentInstallationRequest GetData(EquipmentInstallationRequestViewModel model)
        {
            EquipmentInstallationRequest request = new EquipmentInstallationRequest
            {
                Id = model.Id,
                CampusId = model.CampusId,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                Location = model.Location,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
            return request;
        }

        public static ReplaceComponents GetData(ReplaceComponentViewModel item)
        {
            return new ReplaceComponents
            {
                Id = item.Id,
                ComponentId = item.ComponentId,
                Count = item.Count,
                RequestId = item.RequestId
            };
        }

        public static RefillEquipments GetData(RefillEquipmentViewModel item)
        {
            return new RefillEquipments
            {
                Id = item.Id,
                InventoryNumber = item.InventoryNumber,
                RequestId = item.RequestId
            };
        }

        public static RepairEquipments GetData(RepairEquipmentViewModel item)
        {
            return new RepairEquipments
            {
                Id = item.Id,                
                InventoryNumber = item.InventoryNumber,
                RequestId = item.RequestId
            };
        }

        public static ReplaceEquipments GetData(ReplaceEquipmentViewModel item)
        {
            return new ReplaceEquipments
            {
                Id = item.Id,
                InventoryNumber = item.InventoryNumber,
                EquipmentTypeId = item.EquipmentTypeId,
                RequestId = item.RequestId
            };
        }

        public static VideoCommunicationRequest GetData(VideoCommunicationRequestViewModel model)
        {
            return new VideoCommunicationRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                CampusId = model.CampusId,
                Location = model.Location,
                SubdivisionId = model.SubdivisionId,
                Date = model.Date
            };
        }

        public static PhoneRepairRequest GetData(PhoneRepairRequestViewModel model)
        {
            return new PhoneRepairRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                CampusId = model.CampusId,
                Location = model.Location,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static PhoneNumberAllocationRequest GetData(PhoneNumberAllocationRequestViewModel model)
        {
            return new PhoneNumberAllocationRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                CampusId = model.CampusId,
                Location = model.Location,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static SoftwareReworkRequest GetData(SoftwareReworkRequestViewModel model)
        {
            return new SoftwareReworkRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static SoftwareDevelopmentRequest GetData(SoftwareDevelopmentRequestViewModel model)
        {
            return new SoftwareDevelopmentRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static PhoneLineRepairRequest GetData(PhoneLineRepairRequestViewModel model)
        {
            return new PhoneLineRepairRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                CampusId = model.CampusId,
                Location = model.Location,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static HoldingPhoneLineRequest GetData(HoldingPhoneLineRequestViewModel model)
        {
            return new HoldingPhoneLineRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                CampusId = model.CampusId,
                Location = model.Location,
                SubdivisionId = model.SubdivisionId
            };
        }

        internal static EmailSizeIncreaseRequest GetData(EmailSizeIncreaseRequestViewModel model)
        {
            return new EmailSizeIncreaseRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                Email = model.Email,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static EmailRegistrationRequest GetData(EmailRegistrationRequestViewModel model)
        {
            return new EmailRegistrationRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                Email = model.Email,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static EquipmentReplaceRequest GetData(EquipmentReplaceRequestViewModel model)
        {
            EquipmentReplaceRequest request = new EquipmentReplaceRequest
            {
                Id = model.Id,
                CampusId = model.CampusId,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                Location = model.Location,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
            return request;
        }

        public static ConnectionEquipments GetData(ConnectionEquipmentViewModel connection)
        {
            return new ConnectionEquipments
            {
                Id = connection.Id,
                Count = connection.Count,
                EquipmentTypeId = connection.EquipmentTypeId,
                RequestId = connection.RequestId
            };
        }

        public static EquipmentRepairRequest GetData(EquipmentRepairRequestViewModel model)
        {
            return new EquipmentRepairRequest
            {
                Id = model.Id,
                CampusId = model.CampusId,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                Location = model.Location,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static NetworkConnectionRequest GetData(NetworkConnectionRequestViewModel model)
        {
            return new NetworkConnectionRequest
            {
                Id = model.Id,
                CampusId = model.CampusId,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                Location = model.Location,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static ComponentReplaceRequest GetData(ComponentReplaceRequestViewModel model)
        {
            return new ComponentReplaceRequest
            {
                Id = model.Id,
                CampusId = model.CampusId,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                Location = model.Location,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static TechnicalSupportEventEquipments GetData(TechnicalSupportEventEquipmentViewModel item)
        {
            return new TechnicalSupportEventEquipments { EquipmentName = item.Equipment, Count = item.Count };
        }

        public static TechnicalSupportEventInfos GetData(TechnicalSupportEventInfoViewModel item)
        {
            return new TechnicalSupportEventInfos
            {
                CampusId = item.CampusId,
                Location = item.Location,
                EventDate = item.EventDate,
                StartTime = item.StartTime,
                EndTime = item.EndTime
            };
        }

        public static AccountDisconnectRequest GetData(AccountDisconnectRequestViewModel model)
        {
            return new AccountDisconnectRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static AccountLossRequest GetData(AccountLossRequestViewModel model)
        {
            return new AccountLossRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static AccountRegistrationRequest GetData(AccountRegistrationRequestViewModel model)
        {
            return new AccountRegistrationRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static TechnicalSupportEventRequest GetData(TechnicalSupportEventRequestViewModel model)
        {
            return new TechnicalSupportEventRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static AccountCancellationRequest GetData(AccountCancellationRequestViewModel model)
        {
            return new AccountCancellationRequest
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }

        public static EquipmentRefillRequest GetData(EquipmentRefillRequestViewModel model)
        {
            return new EquipmentRefillRequest
            {
                Id = model.Id,
                CampusId = model.CampusId,
                ClientId = model.ClientId,
                Description = model.Description,
                ExecutorGroupId = model.ExecutorGroupId,
                ExecutorId = model.ExecutorId,
                Justification = model.Justification,
                Location = model.Location,
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                StatusId = model.StatusId,
                Title = model.Title,
                SubdivisionId = model.SubdivisionId
            };
        }
    }
}