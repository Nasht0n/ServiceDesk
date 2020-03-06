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
    /// Репозиторий доступа к данным категории заявок
    /// </summary>
    public class CategoryRepository : IServiceDeskRepository<Category>
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
            .MinimumLevel.Override("ApplicationCategoryRepository", LogEventLevel.Information)
            .WriteTo.File("Logs/DataAccess.text", fileSizeLimitBytes: null, rollingInterval: RollingInterval.Month)
            .CreateLogger();
        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public CategoryRepository(ServiceDeskContext context)
        {
            // Инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Асинхронный метод удаления категории заявки
        /// </summary>
        /// <param name="record">Категория заявки, подлежащая удалению</param>
        /// <returns></returns>
        public async Task Delete(Category record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            logger.Debug($"Начало операции удаления категории заявки");
            logger.Debug($"Информация об удаляемом объекте: {record.ToString()}.");            
            try
            {
                // запуск таймера
                watch.Start();
                // удаление типа заявки из бд
                context.Categories.Remove(record);
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
        /// Асинхронный метод получения списка категорий заявок
        /// </summary>
        /// <returns>Возвращает список категорий заявок</returns>
        public async Task<List<Category>> GetList()
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            logger.Debug($"Получение списка категорий заявки.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                List<Category> result = await context.Categories.ToListAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                if (result == null)
                {
                    logger.Debug($"Статус операции: Операция завершена. Список пуст. Затраченное время: {watch.Elapsed}.");
                }
                else
                {
                    
                    logger.Debug($"Статус операции: Операция завершена. Список категорий заявок получен. Количество записей: {result}. Затраченное время: {watch.Elapsed}.");
                }                
                return result;
            }
            catch (SqlException ex)
            {
                // результат операции в случае возникновения ошибки
                logger.Error($"Статус операции: Получение списка категорий заявок не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }
        /// <summary>
        /// Асинхронный метод добавления записи категории заявки
        /// </summary>
        /// <param name="record">Категория заявки, подлежащая добавлению</param>
        /// <returns>Возвращает объект категории заявки, добавленный в систему</returns>
        public async Task<Category> Insert(Category record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            // строитель строки для логгирования
            logger.Debug("Добавление записи новой категории заявки.");
            logger.Debug($"Информация об объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                var result = context.Categories.Add(record);
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                // результат операции
                logger.Debug($"Статус операции: Операция завершена. Новая категория заявки успешно добавлена. Затраченное время: {watch.Elapsed}.");
                return result;
            }
            catch (SqlException ex)
            {
                // результат операции в случае возникновения ошибки
                logger.Error($"Статус операции: Добавление записи новой категории заявки не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }
        /// <summary>
        /// Асинхронный метод редактирования записи категории заявки
        /// </summary>
        /// <param name="record">Категория заявки, подлежащая редактированию</param>
        /// <returns>Возвращает отредактированный объект категории заявки</returns>
        public async Task<Category> Update(Category record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            // строитель строки для логгирования
            logger.Debug("Редактирование записи категории заявки.");
            logger.Debug($"Информация об объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // для записи результата выполнения метода
                var updated = await context.Categories.FirstOrDefaultAsync(a => a.Id == record.Id);
                if (updated != null)
                {
                    updated.BranchId = record.BranchId;
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
                logger.Error($"Статус операции: Получение списка категорий заявки не произведено. Код ошибки:  {ex.Number}. Сообщение: {ex.Message}.");
                // возвращаем Null как результат поиска
                return null;
            }
        }
    }
}
