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
    /// Класс доступа к хранилищу групп исполнителей
    /// </summary>
    public class ExecutorGroupRepository : IExecutorGroupRepository
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
        public ExecutorGroupRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления группы исполнителей
        /// </summary>
        /// <param name="group">Запись группы исполнителей</param>
        /// <returns>Возвращает объект группы исполнителей</returns>
        public async Task<ExecutorGroup> AddExecutorGroup(ExecutorGroup group)
        {
            log.Debug($"Метод добавления группы исполнителей");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.ExecutorGroups.Add(group);
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
        /// Метод удаления группы исполнителей
        /// </summary>
        /// <param name="group">Объект группы исполнителей</param>
        /// <returns></returns>
        public async Task DeleteExecutorGroup(ExecutorGroup group)
        {
            log.Debug($"Метод удаления группы исполнителей");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.ExecutorGroups.SingleOrDefaultAsync(g => g.Id == group.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.ExecutorGroups.Remove(deleted);
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
                log.Error($"Ошибка удаления записи группы исполнителей: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка групп исполнителей
        /// </summary>
        /// <returns>Возвращает список групп исполнителей</returns>
        public async Task<List<ExecutorGroup>> GetExecutorGroups()
        {
            log.Debug($"Метод получения списка групп исполнителей");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.ExecutorGroups
                    .Include(a => a.Employees)
                    .Include(a => a.Services)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка групп исполнителей: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод обновления группы исполнителей
        /// </summary>
        /// <param name="group">Запись группы исполнителей</param>
        /// <returns>Возвращает объект группы исполнителей</returns>
        public async Task<ExecutorGroup> UpdateExecutorGroup(ExecutorGroup group)
        {
            log.Debug($"Метод обновления группы исполнителей");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.ExecutorGroups.SingleOrDefaultAsync(g => g.Id == group.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Name = group.Name;
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
