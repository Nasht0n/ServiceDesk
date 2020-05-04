using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Employee>> GetEmployees(Subdivision subdivision, bool descendings = false)
        {
            var employees = await employeeRepository.GetEmployees();
            if(descendings) return employees.Where(e => e.SubdivisionId == subdivision.Id).OrderByDescending(e=>e.Surname).ToList();
            else return employees.Where(e => e.SubdivisionId == subdivision.Id).OrderBy(e=>e.Surname).ToList();
        }
    }
}
