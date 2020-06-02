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
    /// Класс доступа к хранилищу областей заявок
    /// </summary>
    public class BranchRepository : IBranchRepository
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
        public BranchRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления области заявки
        /// </summary>
        /// <param name="branch">Область заявки</param>
        /// <returns>Возвращает объект области заявки</returns>
        public async Task<Branch> AddBranch(Branch branch)
        {
            log.Debug("Метод добавления области заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Branches.Add(branch);
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
        /// Метод удаления области заявки
        /// </summary>
        /// <param name="branch">Область заявки</param>
        /// <returns></returns>
        public async Task DeleteBranch(Branch branch)
        {
            log.Debug("Метод удаления области заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Branches.SingleOrDefaultAsync(a => a.Id == branch.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Branches.Remove(deleted);
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
        /// Метод получения списка областей заявок
        /// </summary>
        /// <returns>Возвращает список областей заявок</returns>
        public async Task<List<Branch>> GetBranches()
        {
            log.Debug("Метод получения списка областей заявок.");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Branches.ToListAsync();
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
        /// Метод редактирования области заявки
        /// </summary>
        /// <param name="branch">Область заявки</param>
        /// <returns>Возвращает область заявки</returns>
        public async Task<Branch> UpdateBranch(Branch branch)
        {
            log.Debug($"Метод редактирования области заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Branches.SingleOrDefaultAsync(b => b.Id == branch.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Fullname = branch.Fullname;
                    updated.AreaName = branch.AreaName;
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
