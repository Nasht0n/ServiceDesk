using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEmployeeLogic
    {
        Task<Employee> GetEmployee(int id);
        Task<List<Employee>> GetEmployees(Subdivision subdivision, bool descendings = false);
    }
}
