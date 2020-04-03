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
    public class ComponentRepository : IComponentRepository
    {
        private readonly ServiceDeskContext context;
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

        public ComponentRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Component> Add(Component component)
        {
            try
            {
                log.Information($"Добавление комплектующего оборудования: {component.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Components.Add(component);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Комплектующее оборудования добавлена. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления комплектующего оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task Delete(Component component)
        {
            try
            {
                log.Information($"Удаление комплектующего оборудования: {component.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Components.SingleOrDefaultAsync(a => a.Id == component.Id);
                context.Components.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Комплектующее оборудования удалено. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления комплектующего оборудования. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Component>> GetComponents()
        {
            try
            {
                log.Information($"Получение списка комплектующего оборудования");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Components.ToListAsync();

                watch.Stop();
                log.Debug($"Список комплектующего оборудования получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка комплектующего оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Component> Update(Component component)
        {
            try
            {
                log.Information($"Редактирование комплектующего оборудования: {component.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Components.SingleOrDefaultAsync(b => b.Id == component.Id);

                if (updated != null)
                {
                    updated.Name = component.Name;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Комплектующее оборудования отредактирована. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования комплектующего оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
