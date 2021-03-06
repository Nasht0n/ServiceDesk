using Domain;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.Consumptions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Equipments.Consumptions
{
    public class EquipmentRepairRequestConsumptionRepository : IEquipmentRepairRequestConsumptionRepository
    {
        // Логгер
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        // Контекст данных доступа к данным
        private readonly ServiceDeskContext context;
        // Объявление секундомера для получения времени выполнения метода
        private readonly Stopwatch watch = new Stopwatch();
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст данных доступа к данным</param>
        public EquipmentRepairRequestConsumptionRepository(ServiceDeskContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Метод добавления данных о затратах расходного материала на ремонт оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на ремонт оборудования</param>
        /// <returns>Возвращаем объект затраченных расходных материалов на ремонт оборудования</returns>
        public async Task<EquipmentRepairRequestConsumption> Add(EquipmentRepairRequestConsumption consumption)
        {
            log.Debug($"Метод добавления записи о затратах расходного материала на ремонт оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.EquipmentRepairRequestConsumptions.Add(consumption);
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
        /// Метод удаления данных о затратах расходного материала на ремонт оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на ремонт оборудования</param>
        /// <returns></returns>
        public async Task Delete(EquipmentRepairRequestConsumption consumption)
        {
            log.Debug($"Метод удаления записи о затратах расходного материала на ремонт оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.EquipmentRepairRequestConsumptions.SingleOrDefaultAsync(e => e.Id == consumption.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.EquipmentRepairRequestConsumptions.Remove(deleted);
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
                log.Error($"Ошибка удаления записи о затратах расходного материала на ремонт оборудования: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка затрат расходных материалов на ремонт оборудования
        /// </summary>
        /// <returns>Возврат списка затрат расходных материалов на ремонт оборудования</returns>
        public async Task<List<EquipmentRepairRequestConsumption>> GetRequestConsumptions()
        {
            log.Debug($"Метод получения списка затрат расходных материалов на ремонт оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.EquipmentRepairRequestConsumptions
                    .Include(a => a.Request)
                    .Include(a => a.Consumable)
                    .Include(a => a.Consumable.Unit)
                    .Include(a => a.Consumable.Type)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка затрат расходных материалов на ремонт оборудования: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактирования данных о затратах расходного материала на ремонт оборудования
        /// </summary>
        /// <param name="consumption">Объект расхода материалов на ремонт оборудования</param>
        /// <returns>Возвращаем объект затраченных расходных материалов на ремонт оборудования</returns>
        public async Task<EquipmentRepairRequestConsumption> Update(EquipmentRepairRequestConsumption consumption)
        {
            log.Debug($"Метод редактировния записи о затратах расходного материала на ремонт оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.EquipmentRepairRequestConsumptions.SingleOrDefaultAsync(lc => lc.Id == consumption.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.RequestId = consumption.RequestId;
                    updated.ConsumableId = consumption.ConsumableId;
                    updated.Count = consumption.Count;
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
