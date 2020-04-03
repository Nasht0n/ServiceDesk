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
    public class ConsumableRepository : IConsumableRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ConsumableRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Consumable> Add(Consumable consumable)
        {
            try
            {
                log.Information($"Добавление расходного материала для ремонта: {consumable.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Consumables.Add(consumable);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Расходный материал для ремонта добавлен. Затрачено времени: {watch.Elapsed}.");
                return inserted;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления расходного материала для ремонта. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task Delete(Consumable consumable)
        {
            try
            {
                log.Information($"Удаление расходного материала для ремонта: {consumable.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Consumables.SingleOrDefaultAsync(a => a.Id == consumable.Id);
                context.Consumables.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Расходный материал для ремонта удален. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления расходного материала для ремонта. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Consumable>> GetConsumables()
        {
            try
            {
                log.Information($"Получение списка расходного материала для ремонта оборудования");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.Consumables.ToListAsync();
                watch.Stop();
                log.Debug($"Список расходного материала для ремонта оборудования получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка расходного материала для ремонта оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Consumable> Update(Consumable consumable)
        {
            try
            {
                log.Information($"Редактирование расходного материала для ремонта: {consumable.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Consumables.SingleOrDefaultAsync(b => b.Id == consumable.Id);

                if (updated != null)
                {
                    updated.Name = consumable.Name;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Расходный материал для ремонта отредактирован. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования расходного материала для ремонта. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
