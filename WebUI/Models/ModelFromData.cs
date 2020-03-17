using Domain.Models;
using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using WebUI.ViewModels.Branch;
using WebUI.ViewModels.Campus;
using WebUI.ViewModels.Category;
using WebUI.ViewModels.Consumable;
using WebUI.ViewModels.Employee;
using WebUI.ViewModels.Equipment;
using WebUI.ViewModels.EquipmentType;
using WebUI.ViewModels.ExecutorGroup;
using WebUI.ViewModels.LifeCycles.IT.Equipments;
using WebUI.ViewModels.Priority;
using WebUI.ViewModels.Requests.IT.Equipments;
using WebUI.ViewModels.Service;
using WebUI.ViewModels.Status;
using WebUI.ViewModels.Subdivision;

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
                StatusModel = GetViewModel(request.Status)
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
            model.IsApprovers = user.ApprovalServices.Count > 0 ? true : false;
            model.IsExecutor = request.ExecutorId.HasValue ? true : false;
            model.IsClient = request.ClientId == user.Id ? true : false;
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
                EquipmentTypeId = equipment.EquipmentTypeId,
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
            model.EquipmentTypeId = equipmentType;
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
                SubdivisionModel = GetViewModel(employee.Subdivision),
            };
        }

        public static EmployeesListViewModel GetListViewModel(List<Employee> employees, string search ="", int subdivision=0, int page=0, int pageSize=0)
        {
            EmployeesListViewModel model = new EmployeesListViewModel();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            if (subdivision != 0)
            {
                employees = employees.Where(e => e.SubdivisionId == subdivision).ToList();
                model.SubdivisionId = subdivision;
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

            if(page!=0 && pageSize != 0)
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
                BranchId = category.BranchId,
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
                model.BranchId = branch;
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
                CategoryId = service.CategoryId,
                CategoryModel = GetViewModel(service.Category),
                BranchModel = GetViewModel(service.Category.Branch),
                BranchId = service.Category.BranchId
            };
        }

        public static ServicesListViewModel GetListViewModel(List<Service> services, string search = "", int category = 0, int branch = 0, int page = 0, int pageSize = 0)
        {
            ServicesListViewModel model = new ServicesListViewModel();
            List<ServiceViewModel> serviceModels = new List<ServiceViewModel>();
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
                model.CategoryId = category;
            }
            else
            {
                model.Services = serviceModels;
            }
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