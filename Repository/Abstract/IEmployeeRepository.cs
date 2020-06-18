using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу сотрудников
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Метод добавления сотрудника
        /// </summary>
        /// <param name="employee">Запись сотрудника</param>
        /// <returns>Возвращает объект сотрудника</returns>
        Task<Employee> AddEmployee(Employee employee);
        /// <summary>
        /// Метод обновления записи сотрудника
        /// </summary>
        /// <param name="employee">Запись сотрудника</param>
        /// <returns>Возвращает объект сотрудника</returns>
        Task<Employee> UpdateEmployee(Employee employee);
        /// <summary>
        /// Метод удаления сотрудника
        /// </summary>
        /// <param name="employee">Запись сотрудника</param>
        /// <returns></returns>
        Task DeleteEmployee(Employee employee);
        /// <summary>
        /// Метод получения списка сотрудников
        /// </summary>
        /// <returns>Возвращает список сотрудников</returns>
        Task<List<Employee>> GetEmployees();
    }
}
