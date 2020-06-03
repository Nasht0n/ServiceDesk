using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    /// <summary>
    /// Класс доступа к хранилищу техники
    /// </summary>
    public class EquipmentRepository : IEquipmentRepository
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
        public EquipmentRepository(ServiceDeskContext context)
        {
            // инициализаиця контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления техники
        /// </summary>
        /// <param name="equipment">Запись техники</param>
        /// <returns>Возвращает объект техники</returns>
        public async Task<Equipment> Add(Equipment equipment)
        {
            log.Debug($"Метод добавления техники");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Equipments.Add(equipment);
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно добавлена. Затрачено времени: {watch.Elapsed}.");
                // возвращаем объект прикрепленного файла
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
        /// Метод удаления техники
        /// </summary>
        /// <param name="equipment">Запись техники</param>
        /// <returns></returns>
        public async Task Delete(Equipment equipment)
        {
            log.Debug($"Метод удаления техники");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Equipments.SingleOrDefaultAsync(a => a.Id == equipment.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Equipments.Remove(deleted);
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
                log.Error($"Ошибка удаления записи техники: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка техники
        /// </summary>
        /// <returns>Возвращает список техники</returns>
        public async Task<List<Equipment>> GetEquipments()
        {
            log.Debug($"Метод получения списка техники");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Equipments
                    .Include(e => e.EquipmentType)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка техники: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод обновления технкии
        /// </summary>
        /// <param name="equipment">Запись техники</param>
        /// <returns>Возвращает объект техники (оборудования)</returns>
        public async Task<Equipment> Update(Equipment equipment)
        {
            log.Debug($"Метод обновления технкии");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Equipments.SingleOrDefaultAsync(b => b.Id == equipment.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Name = equipment.Name;
                    updated.InventoryNumber = equipment.InventoryNumber;
                    updated.EquipmentTypeId = equipment.EquipmentTypeId;
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
                // ошибка выполнения метода возвращаем null   
                return null;
            }
        }
    }
}
