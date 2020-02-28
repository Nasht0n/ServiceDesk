using DataAccess.Abstract;
using Domain;
using Domain.Models;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ServiceRepository : IServiceDeskRepository<Service>
    {
        /// <summary>
        /// Контекст данных 
        /// </summary>
        private readonly ServiceDeskContext context;
        /// <summary>
        /// Логгер настроеный на запись в файл
        /// </summary>
        private ILogger logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("ApplicationServiceRepository", LogEventLevel.Information)
            .WriteTo.File("Logs/DataAccess.text", fileSizeLimitBytes: null, rollingInterval: RollingInterval.Month)
            .CreateLogger();
        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ServiceRepository(ServiceDeskContext context)
        {
            // Инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Асинхронный метод удаления вида работы заявки
        /// </summary>
        /// <param name="record">Вида работы заявки, подлежащая удалению</param>
        /// <returns></returns>
        public async Task Delete(Service record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            logger.Debug($"Начало операции удаления вида работы заявки");
            logger.Debug($"Информация об удаляемом объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // удаление типа заявки из бд
                context.Services.Remove(record);
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
        /// Асинхронный метод получения списка видов работ заявок
        /// </summary>
        /// <returns>Возвращает список видов работ заявок</returns>
        public async Task<List<Service>> GetList()
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            logger.Debug($"Получение видов работ заявок.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                List<Service> result = await context.Services.ToListAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                if (result == null)
                {
                    logger.Debug($"Статус операции: Операция завершена. Список пуст. Затраченное время: {watch.Elapsed}.");
                }
                else
                {

                    logger.Debug($"Статус операции: Операция завершена. Список видов работ заявок получен. Количество записей: {result}. Затраченное время: {watch.Elapsed}.");
                }
                return result;
            }
            catch (SqlException ex)
            {
                // результат операции в случае возникновения ошибки
                logger.Error($"Статус операции: Получение списка видов работ заявок не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }
        /// <summary>
        /// Асинхронный метод добавления записи вида работы заявки
        /// </summary>
        /// <param name="record">Вид работы заявки, подлежащий добавлению</param>
        /// <returns>Возвращает объект вида работы заявки, добавленный в систему</returns>
        public async Task<Service> Insert(Service record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            // строитель строки для логгирования
            logger.Debug("Добавление записи нового вида работы заявки.");
            logger.Debug($"Информация об объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                var result = context.Services.Add(record);
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                logger.Debug($"Статус операции: Операция завершена. Новый вид работы заявки успешно добавлена. Затраченное время: {watch.Elapsed}.");
                return result;
            }
            catch (SqlException ex)
            {
                // результат операции в случае возникновения ошибки
                logger.Error($"Статус операции: Добавление записи нового вида работы заявки не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }
        /// <summary>
        /// Асинхронный метод редактирования записи вида работы
        /// </summary>
        /// <param name="record">Вид работы заявки, подлежащий редактированию</param>
        /// <returns>Возвращает отредактированный объект вида работы заявки</returns>
        public async Task<Service> Update(Service record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            // строитель строки для логгирования
            logger.Debug("Редактирование записи вида работы заявки.");
            logger.Debug($"Информация об объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                var updated = await context.Services.FirstOrDefaultAsync(a => a.Id == record.Id);
                if (updated != null)
                {
                    updated.CategoryId = record.CategoryId;
                    updated.Name = record.Name;
                }
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                logger.Debug($"Статус операции: Операция завершена. Запись вида работы успешно изменена. Затраченное время: {watch.Elapsed}.");
                return updated;
            }
            catch (SqlException ex)
            {
                // результат операции в случае возникновения ошибки
                logger.Error($"Статус операции: Редактирование записи вида работы заявки не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }
    }
}
