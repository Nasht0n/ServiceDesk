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
    public class UnitRepository : IUnitRepository
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
        public UnitRepository(ServiceDeskContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Метод добавления еденицы измерения
        /// </summary>
        /// <param name="unit">Еденица измерения</param>
        /// <returns>Возвращает объект еденицы измерения</returns>
        public async Task<Unit> Add(Unit unit)
        {
            log.Debug($"Метод добавления еденицы измерения");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Units.Add(unit);
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
        /// Метод удаления еденицы измерения
        /// </summary>
        /// <param name="unit">Еденица измерения</param>
        /// <returns></returns>
        public async Task Delete(Unit unit)
        {
            log.Debug($"Метод удаления еденицы измерения");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Units.SingleOrDefaultAsync(a => a.Id == unit.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Units.Remove(deleted);
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
                log.Error($"Ошибка удаления еденицы измерения: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка едениц измерения
        /// </summary>
        /// <returns>Возвращает список едениц измерения</returns>
        public async Task<List<Unit>> GetUnits()
        {
            log.Debug($"Метод получения списка едениц измерения");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Units.ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка едениц измерения: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактирования еденицы измерения
        /// </summary>
        /// <param name="unit">Еденица измерения</param>
        /// <returns>Возвращает объект еденицы измерения</returns>
        public async Task<Unit> Update(Unit unit)
        {
            log.Debug($"Метод обновления еденицы измерения");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Units.SingleOrDefaultAsync(s => s.Id == unit.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Fullname = unit.Fullname;
                    updated.Shortname = unit.Shortname;
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
