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
    /// Класс доступа к хранилищу исполнителей закрепленных за подразделением
    /// </summary>
    public class SubdivisionExecutorsRepository : ISubdivisionExecutorsRepository
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
        public SubdivisionExecutorsRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод закрепления исполнителя за подразделением
        /// </summary>
        /// <param name="subdivisionExecutor">Запись закрепления исполнителя за подразделением</param>
        /// <returns>Возвращает объект закрепления исполнителя за подразделением</returns>
        public async Task<SubdivisionExecutor> AddSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor)
        {
            log.Debug($"Метод закрепления исполнителя за подразделением");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.SubdivisionExecutors.Add(subdivisionExecutor);
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
        /// Метод удаления закрепления исполнителя за подразделением
        /// </summary>
        /// <param name="subdivisionExecutor">Объект закрепления исполнителя за подразделением</param>
        /// <returns></returns>
        public async Task DeleteSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor)
        {
            log.Debug($"Метод удаления закрепления исполнителя за подразделением");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.SubdivisionExecutors.SingleOrDefaultAsync(a => a.SubdivisionId == subdivisionExecutor.SubdivisionId && a.EmployeeId == subdivisionExecutor.EmployeeId);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.SubdivisionExecutors.Remove(deleted);
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
                log.Error($"Ошибка удаления записи закрепления исполнителя за подразделением: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка исполнителей закрепленных за подразделением
        /// </summary>
        /// <returns>Возвращает список исполнителей закрепленных за подразделением</returns>
        public async Task<List<SubdivisionExecutor>> GetSubdivisionExecutors()
        {
            log.Debug($"Метод получения списка исполнителей закрепленных за подразделением");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.SubdivisionExecutors
                    .Include(a => a.Subdivision)
                    .Include(a => a.Employee)
                    .Include(a => a.Employee.Subdivision)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка исполнителей закрепленных за подразделением: {ex.Message}.");
                return null;
            }
        }
    }
}
