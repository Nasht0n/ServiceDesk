using Domain;
using Domain.Models.Requests.Network;
using Repository.Abstract.Branches.IT.Network.LifeCycles;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Network.LifeCycles
{
    /// <summary>
    /// Класс доступа к хранилищу жизненного цикла заявки на подключение оборудования к ЛВС
    /// </summary>
    public class NetworkConnectionRequestLifeCycleRepository : INetworkConnectionRequestLifeCycleRepository
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
        public NetworkConnectionRequestLifeCycleRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на подключение оборудования к ЛВС</param>
        /// <returns>Возвращает объект жизненного цикла заявки на подключение оборудования к ЛВС</returns>
        public async Task<NetworkConnectionRequestLifeCycle> Add(NetworkConnectionRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод добавления записи жизненного цикла заявки на подключение оборудования к ЛВС");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.NetworkConnectionRequestLifeCycles.Add(lifeCycle);
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
        /// Метод удаления записи жизненного цикла заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на подключение оборудования к ЛВС</param>
        /// <returns></returns>
        public async Task Delete(NetworkConnectionRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод удаления записи жизненного цикла заявки на подключение оборудования к ЛВС");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.NetworkConnectionRequestLifeCycles.SingleOrDefaultAsync(e => e.Id == lifeCycle.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.NetworkConnectionRequestLifeCycles.Remove(deleted);
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
                log.Error($"Ошибка удаления записи заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на подключение оборудования к ЛВС</returns>
        public async Task<List<NetworkConnectionRequestLifeCycle>> GetRequests()
        {
            log.Debug($"Метод получения списка записей жизненного цикла заявки на подключение оборудования к ЛВС");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.NetworkConnectionRequestLifeCycles
                    .Include(a => a.Request)
                    .Include(a => a.Employee)
                    .Include(a=>a.Employee.Subdivision)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей жизненного цикла заявки на подключение оборудования к ЛВС: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на подключение оборудования к ЛВС</param>
        /// <returns>Возвращает объект жизненного цикла заявки на подключение оборудования к ЛВС</returns>
        public async Task<NetworkConnectionRequestLifeCycle> Update(NetworkConnectionRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод редактировния записи жизненного цикла заявки на подключение оборудования к ЛВС");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.NetworkConnectionRequestLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Date = lifeCycle.Date;
                    updated.EmployeeId = lifeCycle.EmployeeId;
                    updated.Message = lifeCycle.Message;
                    updated.RequestId = lifeCycle.RequestId;
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
                // ошибка выполнения метода возвращаем nul
                return null;
            }
        }
    }
}
