using Domain;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events.Requests;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Events.Requests
{
    /// <summary>
    /// Класс доступа к хранилищу заявок на техническое сопровождение мероприятия
    /// </summary>
    public class TechnicalSupportEventRequestRepository : ITechnicalSupportEventRequestRepository
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
        public TechnicalSupportEventRequestRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="request">Запись заявки на техническое сопровождение мероприятия</param>
        /// <returns>Возвращает объект заявки на техническое сопровождение мероприятия</returns>
        public async Task<TechnicalSupportEventRequest> Add(TechnicalSupportEventRequest request)
        {
            log.Debug($"Метод добавления записи заявки на техническое сопровождение мероприятия");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.TechnicalSupportEventRequests.Add(request);
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
        /// Метод удаления записи заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="request">Запись заявки на техническое сопровождение мероприятия</param>
        /// <returns></returns>
        public async Task Delete(TechnicalSupportEventRequest request)
        {
            log.Debug($"Метод удаления записи жизненного цикла заявки на техническое сопровождение мероприятия");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.TechnicalSupportEventRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.TechnicalSupportEventRequests.Remove(deleted);
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
        /// Метод получения списка записей заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <returns>Возвращает список записей заявки на техническое сопровождение мероприятия</returns>
        public async Task<List<TechnicalSupportEventRequest>> GetRequests()
        {
            log.Debug($"Метод получения списка записей заявки на техническое сопровождение мероприятия");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.TechnicalSupportEventRequests
                    .Include(a => a.Service)
                    .Include(a => a.Service.Category)
                    .Include(a => a.Service.Category.Branch)
                    .Include(a => a.Status)
                    .Include(a => a.Priority)
                    .Include(a => a.Client)
                    .Include(a => a.Client.Subdivision)
                    .Include(a => a.Executor)
                    .Include(a => a.Executor.Subdivision)
                    .Include(a => a.ExecutorGroup)
                    .Include(a => a.Subdivision)
                    .Include(a => a.EventInfos.Select(e => e.Campus))
                    .Include(a => a.EventEquipments)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей заявки на техническое сопровождение мероприятия: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="request">Запись заявки на техническое сопровождение мероприятия</param>
        /// <returns>Возвращает объект заявки на техническое сопровождение мероприятия</returns>
        public async Task<TechnicalSupportEventRequest> Update(TechnicalSupportEventRequest request)
        {
            log.Debug($"Метод редактировния записи заявки на техническое сопровождение мероприятия");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.TechnicalSupportEventRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Title = request.Title;
                    updated.Justification = request.Justification;
                    updated.Description = request.Description;
                    updated.ServiceId = request.ServiceId;
                    updated.StatusId = request.StatusId;
                    updated.PriorityId = request.PriorityId;
                    updated.ClientId = request.ClientId;
                    updated.ExecutorId = request.ExecutorId;
                    updated.ExecutorGroupId = request.ExecutorGroupId;
                    updated.SubdivisionId = request.SubdivisionId;
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
