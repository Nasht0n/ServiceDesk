using Domain;
using Domain.Views;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class RefillRequestJournalRepository : IRefillRequestJournalRepository
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
        public RefillRequestJournalRepository(ServiceDeskContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Метод получения списка входящей корреспонденции
        /// </summary>
        /// <returns>Возвращает список входящей корреспонденции</returns>
        public async Task<List<RefillRequestJournal>> GetJournals()
        {
            log.Debug($"Метод получения списка входящей корреспонденции");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.RefillRequestJournals.ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка входящей корреспонденции: {ex.Message}.");
                return null;
            }
        }
    }
}
