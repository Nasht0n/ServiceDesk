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
    /// Класс доступа к хранилищу учебных корпусов
    /// </summary>
    public class CampusRepository : ICampusRepository
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
        public CampusRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления учебного корпуса
        /// </summary>
        /// <param name="campus">Учебный корпус</param>
        /// <returns>Возвращает объект учебного корпуса</returns>
        public async Task<Campus> Add(Campus campus)
        {
            log.Debug($"Метод добавления учебного корпуса");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Campuses.Add(campus);
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
        /// Метод удаления учебного корпуса
        /// </summary>
        /// <param name="campus">Учебный корпус</param>
        /// <returns></returns>
        public async Task Delete(Campus campus)
        {
            log.Debug($"Метод удаления учебного корпуса");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Campuses.SingleOrDefaultAsync(a => a.Id == campus.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Campuses.Remove(deleted);
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
                log.Error($"Ошибка удаления записи области заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка учебных корпусов
        /// </summary>
        /// <returns>Возвращает список учебных корпусов</returns>
        public async Task<List<Campus>> GetCampuses()
        {
            log.Debug($"Метод получения списка учебных корпусов");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Campuses.ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка областей заявок: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактирования учебного корпуса
        /// </summary>
        /// <param name="campus">Учебный корпус</param>
        /// <returns>Возвращает отредактированный учебный корпус</returns>
        public async Task<Campus> Update(Campus campus)
        {
            log.Debug($"Метод редактирования учебного заведения");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Campuses.SingleOrDefaultAsync(b => b.Id == campus.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Name = campus.Name;
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
