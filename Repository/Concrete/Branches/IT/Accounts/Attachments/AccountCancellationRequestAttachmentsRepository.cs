using Domain;
using Domain.Models.ManyToMany;
using Repository.Abstract.Branches.IT.Accounts.Attachments;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Accounts.Attachments
{
    /// <summary>
    /// Класс доступа к хранилищу прикрепленных файлов заявка аннулирования учетной записи
    /// </summary>
    public class AccountCancellationRequestAttachmentsRepository : IAccountCancellationRequestAttachmentsRepository
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
        public AccountCancellationRequestAttachmentsRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления файла к заявке аннулирования учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns>Объект прикрепленного файла к заявке аннулирования учетной записи</returns>
        public async Task<AccountCancellationRequestAttachment> Add(AccountCancellationRequestAttachment attachment)
        {
            log.Debug($"Метод добавления файла к заявке аннулирования учетной записи");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.AccountCancellationRequestAttachments.Add(attachment);
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
        /// Метод удаления файла заявки аннулирования учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        public async Task Delete(AccountCancellationRequestAttachment attachment)
        {
            log.Debug($"Метод удаления файла заявки аннулирования учетной записи");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.AccountCancellationRequestAttachments.SingleOrDefaultAsync(a => a.AttachmentId == attachment.AttachmentId && a.RequestId == attachment.RequestId);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.AccountCancellationRequestAttachments.Remove(deleted);
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
                log.Error($"Ошибка удаления записи прикрепленного файла: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка прикрепленных файлов заявки на аннулирования учетной записи
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов заявки на аннулирования учетной записи</returns>
        public async Task<List<AccountCancellationRequestAttachment>> GetAttachments()
        {
            log.Debug($"Метод получения списка прикрепленных файлов заявки на аннулирования учетной записи");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.AccountCancellationRequestAttachments
                    .Include(a => a.Attachment)
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
                log.Error($"Ошибка получения списка прикрепленных файлов: {ex.Message}.");
                return null;
            }
        }
    }
}
