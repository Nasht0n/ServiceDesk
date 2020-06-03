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
    /// Класс доступа к хранилищу видов заявок
    /// </summary>
    public class ServiceRepository : IServiceRepository
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
        public ServiceRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления вида заявки
        /// </summary>
        /// <param name="service">Объект вида заявки</param>
        /// <returns>Возвращает добавленный объект вида заявки</returns>
        public async Task<Service> AddService(Service service)
        {
            log.Debug($"Метод добавления вида заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Services.Add(service);
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
        /// Метод удаления вида заявки
        /// </summary>
        /// <param name="service">Объект вида заявки</param>
        /// <returns></returns>
        public async Task DeleteService(Service service)
        {
            log.Debug($"Метод удаления вида заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Services.SingleOrDefaultAsync(s => s.Id == service.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Services.Remove(deleted);
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
                log.Error($"Ошибка удаления записи вида заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка видов заявок
        /// </summary>
        /// <returns>Возвращает список видов заявок</returns>
        public async Task<List<Service>> GetServices()
        {
            log.Debug($"Метод получения списка видов заявок");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Services
                    .Include(e => e.Category)
                    .Include(e => e.Category.Branch)
                    .Include(e => e.Approvers)
                    .Include(e => e.ExecutorGroups)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка видов заявок: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод обновления вида заявки
        /// </summary>
        /// <param name="service">Редактируемый вид заявки</param>
        /// <returns>Возвращает обновленный объект вида заявки</returns>
        public async Task<Service> UpdateService(Service service)
        {
            log.Debug($"Метод обновления вида заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Services.SingleOrDefaultAsync(s => s.Id == service.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Name = service.Name;
                    updated.Visible = service.Visible;
                    updated.ApprovalRequired = service.ApprovalRequired;
                    updated.Controller = service.Controller;
                    updated.CategoryId = service.CategoryId;
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
