using DataAccess.Abstract;
using Domain;
using Domain.Models;
using Serilog;
using Serilog.Events;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    /// <summary>
    /// Репозиторий доступа к данным специализации заявок
    /// </summary>
    public class BrunchRepository : IServiceDeskRepository<Branch>
    {
        /// <summary>
        /// Контекст данных 
        /// </summary>
        private readonly ServiceDeskContext context;
        /// <summary>
        /// Логгер настроеный на запись в файл
        /// </summary>
        private readonly ILogger logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("ApplicationBrunchRepository", LogEventLevel.Information)
            .WriteTo.File("Logs/DataAccess.text", fileSizeLimitBytes: null, rollingInterval: RollingInterval.Month)
            .CreateLogger();
        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public BrunchRepository(ServiceDeskContext context)
        {// Инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Асинхронный метод удаления специализации заявки
        /// </summary>
        /// <param name="record">Cпециализация заявки, подлежащая удалению</param>
        /// <returns></returns>
        public async Task Delete(Branch record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            logger.Debug($"Начало операции удаления специализации заявки");
            logger.Debug($"Информация об удаляемом объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // удаление типа заявки из бд
                context.Brunches.Remove(record);
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                logger.Information($"Статус операции: Операция завершена успешно. Затраченное время: {watch.Elapsed}.");
            }
            catch (SqlException ex)
            {
                logger.Error($"Статус операции: Удаление записи не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
            }
        }
        /// <summary>
        /// Асинхронный метод получения списка специализаций заявок
        /// </summary>
        /// <returns>Возвращает список специализаций заявок</returns>
        public async Task<List<Branch>> GetList()
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            logger.Debug($"Получение списка специализаций заявок.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                List<Branch> result = await context.Brunches.ToListAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                if (result == null)
                {
                    logger.Debug($"Статус операции: Операция завершена. Список пуст. Затраченное время: {watch.Elapsed}.");
                }
                else
                {
                    logger.Debug($"Статус операции: Операция завершена. Список специализаций заявок получен. Количество записей: {result}. Затраченное время: {watch.Elapsed}.");
                }
                return result;
            }
            catch (SqlException ex)
            {
                // результат операции в случае возникновения ошибки
                logger.Error($"Статус операции: Получение списка специализаций заявок не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }
        /// <summary>
        /// Асинхронный метод добавления записи специализации заявки
        /// </summary>
        /// <param name="record">Специализация заявки, подлежащая добавлению</param>
        /// <returns>Возвращает объект специализации заявки, добавленный в систему</returns>
        public async Task<Branch> Insert(Branch record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            // строитель строки для логгирования
            logger.Debug("Добавление записи новой специализации заявки.");
            logger.Debug($"Информация об объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                var result = context.Brunches.Add(record);
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                logger.Debug($"Статус операции: Операция завершена. Новая специализация заявки успешно добавлена. Затраченное время: {watch.Elapsed}.");
                return result;
            }
            catch (SqlException ex)
            {
                // результат операции в случае возникновения ошибки
                logger.Error($"Статус операции: Добавление записи новой специализации заявки не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }

        /// <summary>
        /// Асинхронный метод редактирования записи специализации заявки
        /// </summary>
        /// <param name="record">Специализация заявки, подлежащая редактированию</param>
        /// <returns>Возвращает отредактированный объект специализации заявки</returns>
        public async Task<Branch> Update(Branch record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            // строитель строки для логгирования
            logger.Debug("Редактирование записи специализации заявки.");
            logger.Debug($"Информация об объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                var updated = await context.Brunches.FirstOrDefaultAsync(a => a.Id == record.Id);
                if (updated != null)
                {
                    updated.Name = record.Name;
                }
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                logger.Debug($"Статус операции: Операция завершена. Запись специализации заявки успешно изменена. Затраченное время: {watch.Elapsed}.");
                return updated;
            }
            catch (SqlException ex)
            {
                // результат операции в случае возникновения ошибки
                logger.Error($"Статус операции: Редактирование записи специализации заявки не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }
    }
}
