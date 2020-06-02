using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    /// <summary>
    /// Класс доступа к хранилищу учетных записей системы
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        // Логгер системы
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        // Контекст данных доступа к данным
        private readonly ServiceDeskContext context;
        // Объявление секундомера для получения времени выполнения метода
        private readonly Stopwatch watch = new Stopwatch();
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст данных доступа к данным</param>
        public AccountRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления учетной записи
        /// </summary>
        /// <param name="account">Объект учетной записи</param>
        /// <returns></returns>
        public async Task<Account> AddAccount(Account account)
        {
            log.Debug($"Метод добавления учетной записи.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.Accounts.Add(account);
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно добавлена. Затрачено времени: {watch.Elapsed}.");
                // возврат объекта учетной записи
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
        /// Метод удаления учетной записи
        /// </summary>
        /// <param name="account">Объект учетной записи</param>
        /// <returns></returns>
        public async Task DeleteAccount(Account account)
        {
            log.Debug($"Метод удаления учетной записи.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Accounts.SingleOrDefaultAsync(a => a.Id == account.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Accounts.Remove(deleted);
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
                log.Error($"Ошибка удаления учетной записи: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка учетных записей
        /// </summary>
        /// <returns>Возвращает список учетных записей</returns>
        public async Task<List<Account>> GetAccounts()
        {
            log.Debug($"Метод получения списка учетных записей.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка учетных записей
                var list = await context.Accounts
                    .Include(a => a.Employee)
                    .Include(a => a.Employee.Subdivision)
                    .Include(a => a.Employee.ApprovalServices.Select(s => s.Service))
                    .Include(a => a.Employee.ExecutorGroups.Select(e => e.ExecutorGroup))
                    .Include(a => a.Permissions.Select(p => p.Permission))
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка учетных записей: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактирования учетной записи
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<Account> UpdateAccount(Account account)
        {
            log.Debug("Метод редактирования учетной записи");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Accounts.SingleOrDefaultAsync(a => a.Id == account.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Username = account.Username;
                    updated.Password = account.Password;
                    updated.DateRegistration = account.DateRegistration;
                    updated.DateChangePassword = account.DateChangePassword;
                    updated.LastEnterDateTime = account.LastEnterDateTime;
                    updated.IsEnabled = account.IsEnabled;
                    updated.ChangePasswordOnNextEnter = account.ChangePasswordOnNextEnter;
                    updated.EmployeeId = account.EmployeeId;
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
