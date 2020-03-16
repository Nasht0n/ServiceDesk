using DataAccess.Concrete;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeeService
    {
        private readonly ServiceDesk serviceDesk = new ServiceDesk();

        public List<Employee> GetEmployees()
        {
            return serviceDesk.EmployeeRepository.Get(includeProperties: "Subdivision, ApprovalServices, ExecutorGroups, ExecutorSubdivisions").ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return serviceDesk.EmployeeRepository.Get(filter:e=>e.Id == id, includeProperties: "Subdivision, ApprovalServices, ExecutorGroups, ExecutorSubdivisions").FirstOrDefault();
        }

        public void AddEmployee(Employee employee)
        {
            serviceDesk.EmployeeRepository.Insert(employee);
            serviceDesk.Save();
        }

        public void UpdateEmployee(Employee employee)
        {
            serviceDesk.EmployeeRepository.Update(employee);
            serviceDesk.Save();
        }

        public void DeleteEmployee(Employee employee)
        {
            serviceDesk.EmployeeRepository.Delete(employee);
            serviceDesk.Save();
        }
    }
}
