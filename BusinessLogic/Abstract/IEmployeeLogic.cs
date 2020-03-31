using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEmployeeLogic
    {
        Task<Employee> GetEmployeeById(int id);
        Task<List<Employee>> GetEmployees(int subdivisionId);
    }
}
