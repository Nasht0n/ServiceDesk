using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using WebUI.ViewModels.Employee;
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
            if(!string.IsNullOrWhiteSpace(search)) subdivisions = subdivisions.Where(s => !string.IsNullOrEmpty(search) && (s.Fullname.Contains(search) || s.Shortname.Equals(search))).ToList();
            foreach (var subdivision in subdivisions)
            {
                SubdivisionViewModel item = GetViewModel(subdivision);
                subdivisionModels.Add(item);
            }
            model.Subdivisions = subdivisionModels
                .OrderByDescending(s => s.Fullname)
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

        public static EmployeesListViewModel GetListViewModel(List<Employee> employees, string search, int page, int pageSize)
        {
            EmployeesListViewModel model = new EmployeesListViewModel();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            if (!string.IsNullOrWhiteSpace(search)) employees = employees.Where(s => !string.IsNullOrEmpty(search) && (s.Surname.Contains(search))).ToList();
            foreach (var employee in employees)
            {
                EmployeeViewModel item = GetViewModel(employee);
                employeeViewModels.Add(item);
            }
            model.Employees = employeeViewModels
                .OrderByDescending(s => s.Surname)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = employeeViewModels.Count()
            };
            model.Search = search;
            return model;
        }
    }
}