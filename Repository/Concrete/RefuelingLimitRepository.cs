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
    /// Класс доступа к хранилищу лимитов заправки
    /// </summary>
    public class RefuelingLimitRepository : IRefuelingLimitRepository
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
        public RefuelingLimitRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления лимита заправки
        /// </summary>
        /// <param name="limit">Объект лимита заправки</param>
        /// <returns>Возвращает добавленный объект лимита заправки</returns>
        public async Task<RefuelingLimits> Add(RefuelingLimits limit)
        {
            log.Debug($"Метод добавления лимита заправки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.RefuelingLimits.Add(limit);
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
        /// Метод удаления лимита заправки
        /// </summary>
        /// <param name="limit">Объект лимита заправки</param>
        /// <returns></returns>
        public async Task Delete(RefuelingLimits limit)
        {
            log.Debug($"Метод удаления приоритета заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.RefuelingLimits.SingleOrDefaultAsync(l => l.Id == limit.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.RefuelingLimits.Remove(deleted);
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
                log.Error($"Ошибка удаления записи лимита заправки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка лимитов заправки
        /// </summary>
        /// <returns>Список лимитов заправки</returns>
        public async Task<List<RefuelingLimits>> GetLimits()
        {
            log.Debug($"Метод получения списка лимитов заправки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.RefuelingLimits
                    .Include(l => l.Subdivision)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка лимитов заправки: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод обновления лимита заправки
        /// </summary>
        /// <param name="limit">Объект лимита заправки</param>
        /// <returns>Возвращает отредактированный объект лимита заправки</returns>
        public async Task<RefuelingLimits> Update(RefuelingLimits limit)
        {
            log.Debug($"Метод обновления лимита заправки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.RefuelingLimits.SingleOrDefaultAsync(p => p.Id == limit.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Count = limit.Count;
                    updated.Year = limit.Year;
                    updated.SubdivisionId = limit.SubdivisionId;
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
