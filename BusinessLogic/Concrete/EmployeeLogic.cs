using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employees = await employeeRepository.GetEmployees();
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
