using Domain;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Events
{
    /// <summary>
    /// Класс доступа к хранилищу оборудования устанавливаемого на мероприятии
    /// </summary>
    public class TechnicalSupportEventEquipmentRepository : ITechnicalSupportEventEquipmentRepository
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
        public TechnicalSupportEventEquipmentRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи оборудования устанавливаемого на мероприятии
        /// </summary>
        /// <param name="request">Запись оборудования устанавливаемого на мероприятии</param>
        /// <returns>Возвращает объект оборудования устанавливаемого на мероприятии</returns>
        public async Task<TechnicalSupportEventEquipments> Add(TechnicalSupportEventEquipments equipments)
        {
            log.Debug($"Метод добавления записи оборудования устанавливаемого на мероприятии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.TechnicalSupportEventEquipments.Add(equipments);
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
        /// Метод удаления записи оборудования устанавливаемого на мероприятии
        /// </summary>
        /// <param name="request">Запись оборудования устанавливаемого на мероприятии</param>
        /// <returns></returns>
        public async Task Delete(TechnicalSupportEventEquipments equipments)
        {
            log.Debug($"Метод удаления записи оборудования устанавливаемого на мероприятии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.TechnicalSupportEventEquipments.SingleOrDefaultAsync(r => r.Id == equipments.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    context.TechnicalSupportEventEquipments.Remove(deleted);
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
        /// Метод получения списка записей оборудования устанавливаемого на мероприятии
        /// </summary>
        /// <returns>Возвращает список записей оборудования устанавливаемого на мероприятии</returns>
        public async Task<List<TechnicalSupportEventEquipments>> GetEquipments()
        {
            log.Debug($"Метод получения списка записей оборудования устанавливаемого на мероприятии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.TechnicalSupportEventEquipments
                    .Include(a => a.Request)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей оборудования устанавливаемого на мероприятии: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи оборудования устанавливаемого на мероприятии
        /// </summary>
        /// <param name="request">Запись оборудования устанавливаемого на мероприятии</param>
        /// <returns>Возвращает объект оборудования устанавливаемого на мероприятии</returns>
        public async Task<TechnicalSupportEventEquipments> Update(TechnicalSupportEventEquipments equipments)
        {
            log.Debug($"Метод редактировния записи оборудования устанавливаемого на мероприятии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.TechnicalSupportEventEquipments.SingleOrDefaultAsync(r => r.Id == equipments.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.RequestId = equipments.RequestId;
                    updated.EquipmentName = equipments.EquipmentName;
                    updated.Count = equipments.Count;
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
