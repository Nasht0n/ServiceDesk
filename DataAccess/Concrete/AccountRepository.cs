using DataAccess.Abstract;
using Domain;
using Domain.Models;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AccountRepository : IServiceDeskRepository<Account>
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
            .MinimumLevel.Override("ApplicationAccountRepository", LogEventLevel.Information)
            .WriteTo.File("Logs/DataAccess.text", fileSizeLimitBytes: null, rollingInterval: RollingInterval.Month)
            .CreateLogger();
        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public AccountRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task Delete(Account record)
        {
            // объект для отслеживания времени проведения операции
            Stopwatch watch = new Stopwatch();
            logger.Debug($"Начало операции удаления учетной записи");
            logger.Debug($"Информация об удаляемом объекте: {record.ToString()}.");
            try
            {
                // запуск таймера
                watch.Start();
                // удаление типа заявки из бд
                context.Accounts.Remove(record);
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

        public async Task<List<Account>> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<Account> Insert(Account record)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> Update(Account record)
        {
            throw new NotImplementedException();
        }
    }
}
