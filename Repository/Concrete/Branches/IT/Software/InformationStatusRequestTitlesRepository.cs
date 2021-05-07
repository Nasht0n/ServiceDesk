using Domain;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Software
{
    /// <summary>
    /// Класс доступа к хранилищу подключаемого оборудования к ЛВС
    /// </summary>
    public class InformationStatusRequestTitlesRepository : IInformationStatusRequestTitlesRepository
    {
        // Логгер системы
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        // Контекст данных доступа к данным
        private readonly ServiceDeskContext context;
        // Объявление секундомера для получения времени выполнения метода
        private readonly Stopwatch watch = new Stopwatch();
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст данных доступа к данным</param>
        public InformationStatusRequestTitlesRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи заголовка страницы сайта
        /// </summary>
        /// <param name="title">Запись заголовка страницы сайта</param>
        /// <returns>Возвращает объект заголовка страницы сайта</returns>
        public async Task<InformationStatusRequestTitle> Add(InformationStatusRequestTitle title)
        {
            log.Debug($"Метод добавления записи заголовка страницы сайта");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.InformationStatusRequestTitles.Add(title);
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно добавлена. Затрачено времени: {watch.Elapsed}.");
                // возврат объекта учетной записи
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
        /// Метод удаления записи заголовка страницы сайта
        /// </summary>
        /// <param name="title">Запись заголовка страницы сайта</param>
        /// <returns></returns>
        public async Task Delete(InformationStatusRequestTitle title)
        {
            log.Debug($"Метод удаления записи заголовка страницы сайта");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.InformationStatusRequestTitles.SingleOrDefaultAsync(e => e.Id == title.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.InformationStatusRequestTitles.Remove(deleted);
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
                log.Error($"Ошибка удаления записи заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка записей заголовка страницы сайта
        /// </summary>
        /// <returns>Возвращает список записей заголовка страницы сайта</returns>
        public async Task<List<InformationStatusRequestTitle>> GetTitles()
        {
            log.Debug($"Метод получения списка записей заголовка страницы сайта");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.InformationStatusRequestTitles
                    .Include(a => a.Request)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей заголовка страницы сайта: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи заголовка страницы сайта
        /// </summary>
        /// <param name="title">Запись заголовка страницы сайта</param>
        /// <returns>Возвращает объект заголовка страницы сайта</returns>
        public async Task<InformationStatusRequestTitle> Update(InformationStatusRequestTitle title)
        {
            log.Debug($"Метод редактировния записи заголовка страницы сайта");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.InformationStatusRequestTitles.SingleOrDefaultAsync(e => e.Id == title.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.RequestId = title.RequestId;
                    updated.UpdateDate = title.UpdateDate;
                    updated.Title = title.Title;
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
                // ошибка выполнения метода возвращаем nul
                return null;
            }
        }
    }
}
