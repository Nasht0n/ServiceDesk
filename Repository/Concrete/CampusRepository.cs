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
    public class CampusRepository : ICampusRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public CampusRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Campus> Add(Campus campus)
        {
            try
            {
                log.Information($"Добавление учебного корпуса: {campus.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Campuses.Add(campus);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Учебный корпус добавлен. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления учебного корпуса. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task Delete(Campus campus)
        {
            try
            {
                log.Information($"Удаление учебного корпуса: {campus.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Campuses.SingleOrDefaultAsync(a => a.Id == campus.Id);
                context.Campuses.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Учебный корпус удален. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления учебного корпуса. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Campus>> GetCampuses()
        {
            try
            {
                log.Information($"Получение списка учебных корпусов");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Campuses.ToListAsync();

                watch.Stop();
                log.Debug($"Список учебных корпусов получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка учебных корпусов. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Campus> Update(Campus campus)
        {
            try
            {
                log.Information($"Редактирование учебного корпуса: {campus.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Campuses.SingleOrDefaultAsync(b => b.Id == campus.Id);

                if (updated != null)
                {
                    updated.Name = campus.Name;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Учебный корпус отредактирован. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования учебного корпуса. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
