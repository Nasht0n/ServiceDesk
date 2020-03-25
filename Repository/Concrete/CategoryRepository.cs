using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public CategoryRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                log.Information($"Добавление категории заявки: {category.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Categories.Add(category);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Категория заявки добавлена. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления категории заявки. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteCategory(Category category)
        {
            try
            {
                log.Information($"Удаление категории заявки: {category.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
                context.Categories.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Категория заявки удалена. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления категории заявки. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            try
            {
                log.Information($"Получение списка категорий заявок");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Categories.ToListAsync();

                watch.Stop();
                log.Debug($"Список категорий заявок получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка категорий заявок. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            try
            {
                log.Information($"Редактирование категорий заявки: {category.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);

                if (updated != null)
                {
                    updated.BranchId = category.BranchId;
                    updated.Name = category.Name;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Категория заявки отредактирована. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования категории заявки. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
