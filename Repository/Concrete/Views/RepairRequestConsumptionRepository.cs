using Domain;
using Domain.Views;
using Repository.Abstract.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Views
{
    public class RepairRequestConsumptionRepository : IRepairRequestConsumptionRepository
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
        public RepairRequestConsumptionRepository(ServiceDeskContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Метод получения списка списания расходных материалов
        /// </summary>
        /// <returns>Возвращает список списания расходных материалов</returns>
        public async Task<List<RepairRequestConsumption>> GetConsumptions()
        {
            log.Debug($"Метод получения списка списания расходных материалов");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.RepairRequestConsumptions.ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка списания расходных материалов: {ex.Message}.");
                return null;
            }
        }
    }
}
