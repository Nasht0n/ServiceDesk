using Domain;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Equipments
{
    /// <summary>
    /// Класс доступа к хранилищу заменяемого оборудования
    /// </summary>
    public class ReplaceEquipmentsRepository : IReplaceEquipmentsRepository
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
        public ReplaceEquipmentsRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи заменяемого оборудования
        /// </summary>
        /// <param name="request">Запись заменяемого оборудования</param>
        /// <returns>Возвращает объект заменяемого оборудования</returns>
        public async Task<ReplaceEquipments> Add(ReplaceEquipments equipments)
        {
            log.Debug($"Метод добавления записи заменяемого оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.ReplaceEquipments.Add(equipments);
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
        /// Метод удаления записи заменяемого оборудования
        /// </summary>
        /// <param name="request">Запись заменяемого оборудования</param>
        /// <returns></returns>
        public async Task Delete(ReplaceEquipments equipments)
        {
            log.Debug($"Метод удаления записи заменяемого оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.ReplaceEquipments.SingleOrDefaultAsync(e => e.Id == equipments.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.ReplaceEquipments.Remove(deleted);
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
        /// Метод получения списка записей заменяемого оборудования
        /// </summary>
        /// <returns>Возвращает список записей заменяемого оборудования</returns>
        public async Task<List<ReplaceEquipments>> GetEquipments()
        {
            log.Debug($"Метод получения списка записей заменяемого оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.ReplaceEquipments
                    .Include(a => a.Request)
                    .Include(a => a.EquipmentType)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей заменяемого оборудования: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи заменяемого оборудования
        /// </summary>
        /// <param name="request">Запись заменяемого оборудования</param>
        /// <returns>Возвращает объект заменяемого оборудования</returns>
        public async Task<ReplaceEquipments> Update(ReplaceEquipments equipments)
        {
            log.Debug($"Метод редактировния записи заменяемого оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.ReplaceEquipments.SingleOrDefaultAsync(e => e.Id == equipments.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.InventoryNumber = equipments.InventoryNumber;
                    updated.RequestId = equipments.RequestId;
                    updated.EquipmentTypeId = equipments.EquipmentTypeId;
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
