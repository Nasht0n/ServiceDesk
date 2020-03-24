using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

        public EmployeeRepository() { }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                log.Information($"Добавление сотрудника: {employee.ToString()}");
                Stopwatch watch = new Stopwatch();
                using (var context = new ServiceDeskContext())
                {
                    watch.Start();
                    var inserted = context.Employees.Add(employee);
                    await context.SaveChangesAsync();
                    watch.Stop();
                    log.Debug($"Сотрудник добавлен. Затрачено времени: {watch.Elapsed}.");
                    return inserted;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления сотрудника. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteEmployee(Employee employee)
        {
            try
            {
                log.Information($"Удаление сотрудника: {employee.ToString()}");
                Stopwatch watch = new Stopwatch();
                using (var context = new ServiceDeskContext())
                {
                    watch.Start();
                    var deleted = await context.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id);
                    context.Employees.Remove(deleted);
                    await context.SaveChangesAsync();
                    watch.Stop();
                    log.Debug($"Сотрудник удален. Затрачено времени: {watch.Elapsed}.");
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления сотрудника. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                log.Information($"Получение списка сотрудников.");
                Stopwatch watch = new Stopwatch();
                using (var context = new ServiceDeskContext())
                {
                    watch.Start();
                    var list = await context.Employees
                        .Include(e=>e.Subdivision)
                        .Include(e=>e.ApprovalServices)
                        .Include(e=>e.ExecutorGroups)
                        .Include(e=>e.ExecutorSubdivisions)
                        .ToListAsync();
                    watch.Stop();
                    log.Debug($"Список сотрудников получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                    return list;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка сотрудников. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                log.Information($"Редактирование сотрудника: {employee.ToString()}");
                Stopwatch watch = new Stopwatch();
                using (var context = new ServiceDeskContext())
                {
                    watch.Start();
                    var updated = await context.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id);

                    if (updated != null)
                    {
                        updated.Surname = employee.Surname;
                        updated.Firstname = employee.Firstname;
                        updated.Patronymic = employee.Patronymic;
                        updated.Post = employee.Post;
                        updated.Email = employee.Email;
                        updated.Phone = employee.Phone;
                        updated.HeadOfUnit = employee.HeadOfUnit;
                        updated.SubdivisionId = employee.SubdivisionId;
                    }

                    await context.SaveChangesAsync();
                    watch.Stop();
                    log.Debug($"Сотрудник отредактирован. Затрачено времени: {watch.Elapsed}.");
                    return updated;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования сотрудника. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
