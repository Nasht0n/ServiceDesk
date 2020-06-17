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
    /// Класс доступа к хранилищу ремонтируемой техники
    /// </summary>
    public class RepairEquipmentsRepository : IRepairEquipmentsRepository
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
        public RepairEquipmentsRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи ремонтируемой техники
        /// </summary>
        /// <param name="request">Запись ремонтируемой техники</param>
        /// <returns>Возвращает объект ремонтируемой техники</returns>
        public async Task<RepairEquipments> Add(RepairEquipments repair)
        {
            log.Debug($"Метод добавления записи ремонтируемой техники");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.RepairEquipments.Add(repair);
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
        /// Метод удаления записи ремонтируемой техники
        /// </summary>
        /// <param name="request">Запись ремонтируемой техники</param>
        /// <returns></returns>
        public async Task Delete(RepairEquipments repair)
        {
            log.Debug($"Метод удаления записи ремонтируемой техники");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.RepairEquipments.SingleOrDefaultAsync(e => e.Id == repair.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.RepairEquipments.Remove(deleted);
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
        /// Метод получения списка записей ремонтируемой техники
        /// </summary>
        /// <returns>Возвращает список записей ремонтируемой техники</returns>
        public async Task<List<RepairEquipments>> GetRepairs()
        {
            log.Debug($"Метод получения списка записей ремонтируемой техники");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.RepairEquipments
                    .Include(a => a.Request)
                    .Include(a => a.Consumable)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей ремонтируемой техники: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи ремонтируемой техники
        /// </summary>
        /// <param name="request">Запись ремонтируемой техники</param>
        /// <returns>Возвращает объект ремонтируемой техники</returns>
        public async Task<RepairEquipments> Update(RepairEquipments repair)
        {
            log.Debug($"Метод редактировния записи ремонтируемой техники");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.RepairEquipments.SingleOrDefaultAsync(e => e.Id == repair.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Count = repair.Count;
                    updated.RequestId = repair.RequestId;
                    updated.ConsumableId = repair.ConsumableId;
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
