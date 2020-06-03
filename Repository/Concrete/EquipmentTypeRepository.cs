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
    /// Класс доступа к хранилищу типов оборудования
    /// </summary>
    public class EquipmentTypeRepository : IEquipmentTypeRepository
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
        public EquipmentTypeRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления типа оборудования
        /// </summary>
        /// <param name="equipmentType">Запись типа оборудования</param>
        /// <returns>Возвращает объект типа оборудования</returns>
        public async Task<EquipmentType> Add(EquipmentType equipmentType)
        {
            log.Debug($"Метод добавления типа оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.EquipmentTypes.Add(equipmentType);
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
        /// Метод удаления типа оборудования
        /// </summary>
        /// <param name="equipmentType">Запись типа оборудования</param>
        /// <returns></returns>
        public async Task Delete(EquipmentType equipmentType)
        {
            log.Debug($"Метод удаления типа оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.EquipmentTypes.SingleOrDefaultAsync(a => a.Id == equipmentType.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.EquipmentTypes.Remove(deleted);
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
                log.Error($"Ошибка удаления записи типа оборудования: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка типов оборудования
        /// </summary>
        /// <returns>Возвращает список типов оборудования</returns>
        public async Task<List<EquipmentType>> GetEquipmentTypes()
        {
            log.Debug($"Метод получения списка типов оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.EquipmentTypes.ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка типов оборудования: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод обновления типа оборудования
        /// </summary>
        /// <param name="equipmentType">Запись типа оборудования</param>
        /// <returns>Возвращает объект типа оборудования</returns>
        public async Task<EquipmentType> Update(EquipmentType equipmentType)
        {
            log.Debug($"Метод обновления типа оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.EquipmentTypes.SingleOrDefaultAsync(b => b.Id == equipmentType.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Name = equipmentType.Name;
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
