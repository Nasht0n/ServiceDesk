using Domain;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software.LifeCycles;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Software.LifeCycles
{
    /// <summary>
    /// Класс доступа к хранилищу жизненного цикла заявки о состоянии информации
    /// </summary>
    public class InformationStatusRequestLifeCycleRepository : IInformationStatusRequestLifeCycleRepository
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
        public InformationStatusRequestLifeCycleRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки о состоянии информации
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки о состоянии информации</param>
        /// <returns>Возвращает объект жизненного цикла заявки о состоянии информации</returns>
        public async Task<InformationStatusRequestLifeCycle> Add(InformationStatusRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод добавления записи жизненного цикла заявки о состоянии информации");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.InformationStatusRequestLifeCycles.Add(lifeCycle);
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
        /// Метод удаления записи жизненного цикла заявки о состоянии информации
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки о состоянии информации</param>
        /// <returns></returns>
        public async Task Delete(InformationStatusRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод удаления записи жизненного цикла заявки о состоянии информации");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.InformationStatusRequestLifeCycles.SingleOrDefaultAsync(e => e.Id == lifeCycle.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.InformationStatusRequestLifeCycles.Remove(deleted);
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
        /// Метод получения списка записей жизненного цикла заявки о состоянии информации
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки о состоянии информации</returns>
        public async Task<List<InformationStatusRequestLifeCycle>> GetLifeCycles()
        {
            log.Debug($"Метод получения списка записей жизненного цикла заявки о состоянии информации");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.InformationStatusRequestLifeCycles
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
                log.Error($"Ошибка получения списка записей жизненного цикла заявки о состоянии информации: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки о состоянии информации
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки о состоянии информации</param>
        /// <returns>Возвращает объект жизненного цикла заявки о состоянии информации</returns>
        public async Task<InformationStatusRequestLifeCycle> Update(InformationStatusRequestLifeCycle lifeCycle)
        {
            log.Debug($"Метод редактировния записи жизненного цикла заявки о состоянии информации");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.InformationStatusRequestLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
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
