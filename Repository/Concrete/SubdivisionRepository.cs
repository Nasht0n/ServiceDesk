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
    /// Класс доступа к хранилищу подразделений
    /// </summary>
    public class SubdivisionRepository : ISubdivisionRepository
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
        public SubdivisionRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления подразделения
        /// </summary>
        /// <param name="subdivision">Запись подразделения</param>
        /// <returns>Возвращает объект подразделения</returns>
        public async Task<Subdivision> AddSubdivision(Subdivision subdivision)
        {
            log.Debug($"Метод добавления подразделения");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Subdivisions.Add(subdivision);
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
        /// Метод удаления подразделения
        /// </summary>
        /// <param name="subdivision">Объект подразделения</param>
        /// <returns></returns>
        public async Task DeleteSubdivision(Subdivision subdivision)
        {
            log.Debug($"Метод удаления подразделения");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Subdivisions.SingleOrDefaultAsync(a => a.Id == subdivision.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Subdivisions.Remove(deleted);
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
                log.Error($"Ошибка удаления записи подразделения: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка подразделений
        /// </summary>
        /// <returns>Возвращает список подразделений</returns>
        public async Task<List<Subdivision>> GetSubdivisions()
        {
            log.Debug($"Метод получения списка подразделений");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Subdivisions
                    .Include(a => a.SubdivisionExecutors)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка подразделений заявок: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод обновления подразделения
        /// </summary>
        /// <param name="subdivision">Объект подразделения</param>
        /// <returns>Возвращает отредактированный объект подразделения</returns>
        public async Task<Subdivision> UpdateSubdivision(Subdivision subdivision)
        {
            log.Debug($"Метод обновления подразделения");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Subdivisions.SingleOrDefaultAsync(s => s.Id == subdivision.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Fullname = subdivision.Fullname;
                    updated.Shortname = subdivision.Shortname;
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
