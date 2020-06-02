using Domain;
using Domain.Models.ManyToMany;
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
    /// Класс доступа к хранилищу разрешений прав доступа для учетных записей
    /// </summary>
    public class AccountPermissionRepository : IAccountPermissionRepository
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
        public AccountPermissionRepository(ServiceDeskContext context)
        {
            // инциализация контекста
            this.context = context;
        }
        /// <summary>
        /// Метод добавления разрешения права доступа для учетной записи пользователя
        /// </summary>
        /// <param name="accountPermission">Объект разрешения учетной записи</param>
        /// <returns>Возвращает объект разрешения учетной записи</returns>
        public async Task<AccountPermission> AddAccountPermission(AccountPermission accountPermission)
        {
            log.Debug($"Метод добавления разрешения права доступа учетной записи.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление разрешения права доступа учетной записи
                var inserted = context.AccountPermissions.Add(accountPermission);
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно добавлена. Затрачено времени: {watch.Elapsed}.");
                // возврат объекта разрешения учетной записи
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
        /// Метод удаления разрешения права доступа для учетной записи пользователя
        /// </summary>
        /// <param name="accountPermission">Объект разрешения учетной записи</param>
        /// <returns></returns>
        public async Task DeleteAccountPermission(AccountPermission accountPermission)
        {
            log.Debug($"Метод удаления разрешения права доступа учетной записи.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.AccountPermissions.SingleOrDefaultAsync(a => a.PermissionId == accountPermission.PermissionId && a.AccountId == accountPermission.AccountId);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.AccountPermissions.Remove(deleted);
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
                log.Error($"Ошибка удаления разрешения права доступа учетной записи: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка разрешений прав доступа для учетных записей системы
        /// </summary>
        /// <returns></returns>
        public async Task<List<AccountPermission>> GetAccountPermissions()
        {
            log.Debug($"Метод получения списка разрешений права доступа для учетных записей.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.AccountPermissions
                    .Include(a => a.Account)
                    .Include(a => a.Permission)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка разрешений права доступа для учетных записей: {ex.Message}.");
                return null;
            }
        }
    }
}
