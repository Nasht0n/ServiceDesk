using Domain.Models;
using System;
using WebUI.ViewModels.Branch;
using WebUI.ViewModels.Campus;
using WebUI.ViewModels.Category;
using WebUI.ViewModels.Employee;
using WebUI.ViewModels.Equipment;
using WebUI.ViewModels.EquipmentType;
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
                SubdivisionId = model.SubdivisionModel.Id
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
                Name = model.Name
            };
        }

        public static Category GetData(CategoryViewModel model)
        {
            return new Category
            {
                Id = model.Id,
                Name = model.Name,
                BranchId = model.BranchId
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
                CategoryId = model.CategoryId                
            };
        }
    }
}