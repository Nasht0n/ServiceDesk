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
    public class ServiceRepository : IServiceRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ServiceRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Service> AddService(Service service)
        {
            try
            {
                log.Information($"Добавление вида работы: {service.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Services.Add(service);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Вид работы добавлен. Затрачено времени: {watch.Elapsed}.");
                return inserted;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления вида работы. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteService(Service service)
        {
            try
            {
                log.Information($"Удаление вида работы: {service.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Services.SingleOrDefaultAsync(s => s.Id == service.Id);
                context.Services.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Вид работы удален. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления вида работы. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Service>> GetServices()
        {
            try
            {
                log.Information($"Получение списка видов работы.");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Services
                    .Include(e => e.Category)
                    .Include(e=>e.Category.Branch)
                    .Include(e => e.Approvers)
                    .Include(e => e.ExecutorGroups)
                    .ToListAsync();
                watch.Stop();
                log.Debug($"Список видов работы получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка видов работы. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Service> UpdateService(Service service)
        {
            try
            {
                log.Information($"Редактирование вида работы: {service.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Services.SingleOrDefaultAsync(s => s.Id == service.Id);

                if (updated != null)
                {
                    updated.Name = service.Name;
                    updated.Visible = service.Visible;
                    updated.ApprovalRequired = service.ApprovalRequired;
                    updated.Controller = service.Controller;
                    updated.CategoryId = service.CategoryId;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Вид работы отредактирован. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования вида работы. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
