using Domain;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.LifeCycles;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Communication.LifeCycles
{
    /// <summary>
    /// Класс доступа к хранилищу жизненного цикла заявки на проведение телефонной линии
    /// </summary>
    public class HoldingPhoneLineRequestLifeCycleRepository : IHoldingPhoneLineRequestLifeCycleRepository
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
        public HoldingPhoneLineRequestLifeCycleRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на проведение телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение телефонной линии</param>
        /// <returns>Возвращает объект жизненного цикла заявки на проведение телефонной линии</returns>
        public async Task<HoldingPhoneLineRequestLifeCycle> Add(HoldingPhoneLineRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод добавления записи жизненного цикла заявки на проведение телефонной линии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.HoldingPhoneLineRequestLifeCycles.Add(lifeCycle);
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
        /// Метод удаления записи жизненного цикла заявки на проведение телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение телефонной линии</param>
        /// <returns></returns>
        public async Task Delete(HoldingPhoneLineRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод удаления записи жизненного цикла заявки на проведение телефонной линии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.HoldingPhoneLineRequestLifeCycles.SingleOrDefaultAsync(e => e.Id == lifeCycle.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.HoldingPhoneLineRequestLifeCycles.Remove(deleted);
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
                log.Error($"Ошибка удаления записи жизненного цикла заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на проведение телефонной линии
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на проведение телефонной линии</returns>
        public async Task<List<HoldingPhoneLineRequestLifeCycle>> GetLifeCycles()
        {
            log.Debug($"Метод получения списка записей жизненного цикла заявки на проведение телефонной линии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.HoldingPhoneLineRequestLifeCycles
                    .Include(a => a.Request)
                    .Include(a => a.Employee)
                    .Include(a => a.Employee.Subdivision)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей жизненного цикла заявки на проведение телефонной линии: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на проведение телефонной линии
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на проведение телефонной линии</param>
        /// <returns>Возвращает объект жизненного цикла заявки на проведение телефонной линии</returns>
        public async Task<HoldingPhoneLineRequestLifeCycle> Update(HoldingPhoneLineRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод редактировния записи жизненного цикла заявки на проведение телефонной линии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.HoldingPhoneLineRequestLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
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
