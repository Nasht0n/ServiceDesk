using Domain;
using Domain.Models;
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
    /// Класс доступа к хранилищу прикрепленных файлов в заявках системы
    /// </summary>
    public class AttachmentRepository : IAttachmentRepository
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
        public AttachmentRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи прикрепленного файла
        /// </summary>
        /// <param name="attachment">Прикрепленный файл</param>
        /// <returns>Объект прикрепленного файла</returns>
        public async Task<Attachment> Add(Attachment attachment)
        {
            log.Debug($"Метод добавления записи прикрепленного файла");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Attachments.Add(attachment);
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
        /// Метод удаления записи прикрепленного файла
        /// </summary>
        /// <param name="attachment">Прикрепленный файл</param>
        /// <returns></returns>
        public async Task Delete(Attachment attachment)
        {
            log.Debug($"Метод удаления записи прикрепленного файла");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Attachments.SingleOrDefaultAsync(a => a.Id == attachment.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Attachments.Remove(deleted);
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
        /// Метод получения списка прикрепленных файлов
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов</returns>
        public async Task<List<Attachment>> GetAttachments()
        {
            log.Debug("Метод получения списка прикрепленных файлов.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Attachments.ToListAsync();
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
        /// <summary>
        /// Метод редактирования записи прикрепленного файла
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        public async Task<Attachment> Update(Attachment attachment)
        {
            log.Debug($"Метод редактирования записи прикрепленного файла");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Attachments.SingleOrDefaultAsync(b => b.Id == attachment.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Filename = attachment.Filename;
                    updated.DateUploaded = attachment.DateUploaded;
                    updated.Path = attachment.Path;
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
                // ошибка выполнения метода возвращаем null     
                return null;
            }
        }
    }

}