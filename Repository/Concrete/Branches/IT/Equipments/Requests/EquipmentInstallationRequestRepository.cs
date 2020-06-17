using Domain;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.Requests;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Equipments.Requests
{
    /// <summary>
    /// Класс доступа к хранилищу заявок на установку оборудования
    /// </summary>
    public class EquipmentInstallationRequestRepository : IEquipmentInstallationRequestRepository
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
        public EquipmentInstallationRequestRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи заявки на установку оборудования
        /// </summary>
        /// <param name="request">Запись заявки на установку оборудования</param>
        /// <returns>Возвращает объект заявки на установку оборудования</returns>
        public async Task<EquipmentInstallationRequest> Add(EquipmentInstallationRequest request)
        {
            log.Debug($"Метод добавления записи заявки на установку оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.EquipmentInstallationRequests.Add(request);
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
        /// Метод удаления записи заявки на установку оборудования
        /// </summary>
        /// <param name="request">Запись заявки на установку оборудования</param>
        /// <returns></returns>
        public async Task Delete(EquipmentInstallationRequest request)
        {
            log.Debug($"Метод удаления записи жизненного цикла заявки на установку оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.EquipmentInstallationRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.EquipmentInstallationRequests.Remove(deleted);
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
        /// Метод получения списка записей заявки на установку оборудования
        /// </summary>
        /// <returns>Возвращает список записей заявки на установку оборудования</returns>
        public async Task<List<EquipmentInstallationRequest>> GetRequests()
        {
            log.Debug($"Метод получения списка записей заявки на установку оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.EquipmentInstallationRequests
                    .Include(a => a.Campus)
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
                    .Include(a => a.InstallationEquipments.Select(it => it.EquipmentType))
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей заявки на установку оборудования: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи заявки на установку оборудования
        /// </summary>
        /// <param name="request">Запись заявки на установку оборудования</param>
        /// <returns>Возвращает объект заявки на установку оборудования</returns>
        public async Task<EquipmentInstallationRequest> Update(EquipmentInstallationRequest request)
        {
            log.Debug($"Метод редактировния записи заявки на установку оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.EquipmentInstallationRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Location = request.Location;
                    updated.CampusId = request.CampusId;
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
