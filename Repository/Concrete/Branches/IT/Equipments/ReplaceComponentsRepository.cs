using Domain;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Equipments
{
    /// <summary>
    /// Класс доступа к хранилищу заменяемого комплектующего
    /// </summary>
    public class ReplaceComponentsRepository : IReplaceComponentsRepository
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
        public ReplaceComponentsRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи заменяемого комплектующего
        /// </summary>
        /// <param name="request">Запись заменяемого комплектующего</param>
        /// <returns>Возвращает объект заменяемого комплектующего</returns>
        public async Task<ReplaceComponents> Add(ReplaceComponents components)
        {
            log.Debug($"Метод добавления записи заменяемого комплектующего");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.ReplaceComponents.Add(components);
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
        /// Метод удаления записи заменяемого комплектующего
        /// </summary>
        /// <param name="request">Запись заменяемого комплектующего</param>
        /// <returns></returns>
        public async Task Delete(ReplaceComponents components)
        {
            log.Debug($"Метод удаления записи заменяемого комплектующего");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.ReplaceComponents.SingleOrDefaultAsync(c => c.Id == components.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.ReplaceComponents.Remove(deleted);
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
        /// Метод получения списка записей заменяемого комплектующего
        /// </summary>
        /// <returns>Возвращает список записей заменяемого комплектующего</returns>
        public async Task<List<ReplaceComponents>> GetComponents()
        {
            log.Debug($"Метод получения списка записей заменяемого комплектующего");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.ReplaceComponents
                    .Include(a => a.Request)
                    .Include(a => a.Component)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей заменяемого комплектующего: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи заменяемого комплектующего
        /// </summary>
        /// <param name="request">Запись заменяемого комплектующего</param>
        /// <returns>Возвращает объект заменяемого комплектующего</returns>
        public async Task<ReplaceComponents> Update(ReplaceComponents components)
        {
            log.Debug($"Метод редактировния записи заменяемого комплектующего");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.ReplaceComponents.SingleOrDefaultAsync(c => c.Id == components.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Count = components.Count;
                    updated.RequestId = components.RequestId;
                    updated.ComponentId = components.ComponentId;
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
