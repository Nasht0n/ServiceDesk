using Domain;
using Domain.Models.Requests.Network;
using Repository.Abstract.Branches.IT.Network;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Network
{
    /// <summary>
    /// Класс доступа к хранилищу подключаемого оборудования к ЛВС
    /// </summary>
    public class ConnectionEquipmentsRepository : IConnectionEquipmentsRepository
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
        public ConnectionEquipmentsRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи подключаемого оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись подключаемого оборудования к ЛВС</param>
        /// <returns>Возвращает объект подключаемого оборудования к ЛВС</returns>
        public async Task<ConnectionEquipments> Add(ConnectionEquipments equipments)
        {
            log.Debug($"Метод добавления записи подключаемого оборудования к ЛВС");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.ConnectionEquipments.Add(equipments);
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
        /// Метод удаления записи подключаемого оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись подключаемого оборудования к ЛВС</param>
        /// <returns></returns>
        public async Task Delete(ConnectionEquipments equipments)
        {
            log.Debug($"Метод удаления записи подключаемого оборудования к ЛВС");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.ConnectionEquipments.SingleOrDefaultAsync(e => e.Id == equipments.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.ConnectionEquipments.Remove(deleted);
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
        /// Метод получения списка записей подключаемого оборудования к ЛВС
        /// </summary>
        /// <returns>Возвращает список записей подключаемого оборудования к ЛВС</returns>
        public async Task<List<ConnectionEquipments>> GetEquipments()
        {
            log.Debug($"Метод получения списка записей подключаемого оборудования к ЛВС");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.ConnectionEquipments
                    .Include(a => a.EquipmentType)
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
                log.Error($"Ошибка получения списка записей подключаемого оборудования к ЛВС: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи подключаемого оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись подключаемого оборудования к ЛВС</param>
        /// <returns>Возвращает объект подключаемого оборудования к ЛВС</returns>
        public async Task<ConnectionEquipments> Update(ConnectionEquipments equipments)
        {
            log.Debug($"Метод редактировния записи подключаемого оборудования к ЛВС");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.ConnectionEquipments.SingleOrDefaultAsync(e => e.Id == equipments.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Count = equipments.Count;
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
