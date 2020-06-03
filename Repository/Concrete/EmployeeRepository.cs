using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    /// <summary>
    /// Класс доступа к хранилищу сотрудников
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        // Логгер
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        // Контекст данных доступа к данным
        private readonly ServiceDeskContext context;
        // Объявление секундомера для получения времени выполнения метода
        private readonly Stopwatch watch = new Stopwatch();
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст данных доступа к данным</param>
        public EmployeeRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления сотрудника
        /// </summary>
        /// <param name="employee">Запись сотрудника</param>
        /// <returns>Возвращает объект сотрудника</returns>
        public async Task<Employee> AddEmployee(Employee employee)
        {
            log.Debug($"Метод добавления сотрудника");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Employees.Add(employee);
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно добавлена. Затрачено времени: {watch.Elapsed}.");
                // возвращаем объект прикрепленного файла
                return inserted;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления записи: {ex.Message}.");
                // ошибка выполнения метода возвращаем null  
                return null;
            }
        }
        /// <summary>
        /// Метод удаления сотрудника
        /// </summary>
        /// <param name="employee">Запись сотрудника</param>
        /// <returns></returns>
        public async Task DeleteEmployee(Employee employee)
        {
            log.Debug($"Метод удаления сотрудника");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Employees.Remove(deleted);
                    log.Debug($"Сохранение изменений.");
                    // сохранение изменений
                    await context.SaveChangesAsync();
                    // остановка таймера
                    watch.Stop();
                    log.Debug($"Запись успешно удалена. Затрачено времени: {watch.Elapsed}.");
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления записи области заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка сотрудников
        /// </summary>
        /// <returns>Возвращает список сотрудников</returns>
        public async Task<List<Employee>> GetEmployees()
        {
            log.Debug($"Метод получения списка сотрудников");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Employees
                    .Include(e => e.Subdivision)
                    .Include(e => e.ApprovalServices)
                    .Include(e => e.ExecutorGroups)
                    .Include(e => e.ExecutorSubdivisions)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка сотрудников: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод обновления записи сотрудника
        /// </summary>
        /// <param name="employee">Запись сотрудника</param>
        /// <returns>Возвращает объект сотрудника</returns>
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            log.Debug($"Метод обновления записи сотрудника.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Surname = employee.Surname;
                    updated.Firstname = employee.Firstname;
                    updated.Patronymic = employee.Patronymic;
                    updated.Post = employee.Post;
                    updated.Email = employee.Email;
                    updated.Phone = employee.Phone;
                    updated.HeadOfUnit = employee.HeadOfUnit;
                    updated.SubdivisionId = employee.SubdivisionId;
                }
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно отредактирована. Затрачено времени: {watch.Elapsed}.");
                // возврат объекта учетной записи
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования записи: {ex.Message}.");
                // ошибка выполнения метода возвращаем null   
                return null;
            }
        }
    }
}
