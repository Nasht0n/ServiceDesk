using Domain;
using Domain.Models.ManyToMany;
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
    /// Класс доступа к хранилищу групп исполнителей закрепленных за видом заявок
    /// </summary>
    public class ServicesExecutorGroupsRepository : IServicesExecutorGroupsRepository
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
        public ServicesExecutorGroupsRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод закрепления группы исполнителей за видом заявки
        /// </summary>
        /// <param name="servicesExecutorGroup">Запись закрепления группы исполнителей за видом заявки</param>
        /// <returns>Возвращает объект закрепленния группы исполнителей за видом заявки</returns>
        public async Task<ServicesExecutorGroup> Add(ServicesExecutorGroup servicesExecutorGroup)
        {
            log.Debug($"Метод закрепления группы исполнителей за видом заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.ServicesExecutorGroups.Add(servicesExecutorGroup);
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
        /// Метод удаления записи закрепления группы исполнителей за видом заявки
        /// </summary>
        /// <param name="servicesExecutorGroup">Удаляемая запись закрепления группы исполнителей за видом заявки</param>
        /// <returns></returns>
        public async Task Delete(ServicesExecutorGroup servicesExecutorGroup)
        {
            log.Debug($"Метод удаления записи закрепления группы исполнителей за видом заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.ServicesExecutorGroups.SingleOrDefaultAsync(sa => sa.ServiceId == servicesExecutorGroup.ServiceId && sa.ExecutorGroupId == servicesExecutorGroup.ExecutorGroupId);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.ServicesExecutorGroups.Remove(deleted);
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
                log.Error($"Ошибка удаления записи закрепления группы исполнителей за видом заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка закрепленных групп исполнителей за видами заявок
        /// </summary>
        /// <returns>Возвращает список закрепленных групп исполнителей за видами заявок</returns>
        public async Task<List<ServicesExecutorGroup>> GetServicesExecutorGroups()
        {
            log.Debug($"Метод получения списка закрепленных групп исполнителей за видами заявок");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.ServicesExecutorGroups
                    .Include(a => a.ExecutorGroup)
                    .Include(a => a.Service)
                    .Include(a => a.Service.Category)
                    .Include(a => a.Service.Category.Branch)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка закрепленных групп исполнителей за видами заявок: {ex.Message}.");
                return null;
            }
        }
    }
}
