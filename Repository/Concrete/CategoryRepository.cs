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
    /// Класс доступа к хранилищу категорий заявок
    /// </summary>
    public class CategoryRepository : ICategoryRepository
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
        public CategoryRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления категории заявок
        /// </summary>
        /// <param name="category">Категория заявок</param>
        /// <returns>Возвращает объект добавленной категории заявки</returns>
        public async Task<Category> AddCategory(Category category)
        {
            log.Debug("Метод добавления категории заявок");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.Categories.Add(category);
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
        /// Метод удаления категории заявок
        /// </summary>
        /// <param name="category">Категория заявок</param>
        /// <returns></returns>
        public async Task DeleteCategory(Category category)
        {
            log.Debug("Метод удаления категории заявок");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.Categories.Remove(deleted);
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
        /// Метод получения списка категорий заявок
        /// </summary>
        /// <returns>Получение списка категорий заявок</returns>
        public async Task<List<Category>> GetCategories()
        {
            log.Debug($"Метод получения списка категорий заявок");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.Categories
                    .Include(c => c.Branch)
                    .ToListAsync();
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
        /// Метод редактирования категории заявок
        /// </summary>
        /// <param name="category">Категория заявок</param>
        /// <returns>Возвращает объект категории заявок</returns>
        public async Task<Category> UpdateCategory(Category category)
        {
            log.Debug($"Метод редактирования категории заявок");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.BranchId = category.BranchId;
                    updated.Name = category.Name;
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
