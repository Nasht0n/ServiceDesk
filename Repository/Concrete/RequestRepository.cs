using Domain;
using Domain.Views;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data.Entity;
using Serilog;

namespace Repository.Concrete
{
    /// <summary>
    /// Класс доступа к хранилищу заявок системы
    /// </summary>
    public class RequestRepository : IRequestRepository
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
        public RequestRepository(ServiceDeskContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Метод получения списка заявок системы
        /// </summary>
        /// <returns>Возвращает список заявок системы</returns>
        public async Task<List<Requests>> GetRequests()
        {
            log.Debug($"Метод получения списка заявок системы");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Requests
                    .Include(r => r.Service)
                    .Include(r => r.Service.Category)
                    .Include(r => r.Service.Category.Branch)
                    .Include(r => r.Status)
                    .Include(r => r.Priority)
                    .Include(r => r.Client)
                    .Include(r => r.Client.Subdivision)
                    .Include(r => r.Executor)
                    .Include(r => r.Executor.Subdivision)
                    .Include(r => r.ExecutorGroup)
                    .Include(r => r.Subdivision)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка заявок системы: {ex.Message}.");
                return null;
            }
        }
    }
}
