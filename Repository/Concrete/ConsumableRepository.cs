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
    /// Класс доступа к хранилищу расходных материалов
    /// </summary>
    public class ConsumableRepository : IConsumableRepository
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
        public ConsumableRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }

        public async Task<Consumable> Add(Consumable consumable)
        {
            try
            {
                watch.Start();
                var inserted = context.Consumables.Add(consumable);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(Consumable consumable)
        {
            try
            {
                watch.Start();
                var deleted = await context.Consumables.SingleOrDefaultAsync(a => a.Id == consumable.Id);
                context.Consumables.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<List<Consumable>> GetConsumables()
        {
            try
            {
                watch.Start();
                var list = await context.Consumables.ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Consumable> Update(Consumable consumable)
        {
            try
            {
                watch.Start();
                var updated = await context.Consumables.SingleOrDefaultAsync(b => b.Id == consumable.Id);
                if (updated != null)
                {
                    updated.Name = consumable.Name;
                }
                await context.SaveChangesAsync();
                watch.Stop();
                return updated;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
