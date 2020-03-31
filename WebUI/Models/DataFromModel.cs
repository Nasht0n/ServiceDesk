using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Models.Requests.Equipment;
using WebUI.ViewModels.Account;
using WebUI.ViewModels.Branch;
using WebUI.ViewModels.Campus;
using WebUI.ViewModels.Category;
using WebUI.ViewModels.Consumable;
using WebUI.ViewModels.Employee;
using WebUI.ViewModels.Equipment;
using WebUI.ViewModels.EquipmentType;
using WebUI.ViewModels.ExecutorGroup;
using WebUI.ViewModels.Permission;
using WebUI.ViewModels.Requests.IT.Equipments;
using WebUI.ViewModels.Service;
using WebUI.ViewModels.Subdivision;

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
                EquipmentTypeId = model.EquipmentTypeId
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
                ChangePasswordOnNextEnter = model.ChangePasswordOnNextEnter
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
            return new Permission { Id = permission.Id, Description = permission.Name, Title = permission.Title };
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
                ConsumableId = item.ConsumableId,
                RequestId = item.RequestId,
                Count = item.Count
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