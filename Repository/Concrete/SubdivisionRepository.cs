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
    public class SubdivisionRepository : ISubdivisionRepository
    {        
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public SubdivisionRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Subdivision> AddSubdivision(Subdivision subdivision)
        {
            try
            {
                log.Information($"Добавление подразделения: {subdivision.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Subdivisions.Add(subdivision);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Подразделение добавлено. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления подразделения. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteSubdivision(Subdivision subdivision)
        {
            try
            {
                log.Information($"Удаление подразделения: {subdivision.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Subdivisions.SingleOrDefaultAsync(a => a.Id == subdivision.Id);
                context.Subdivisions.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Подразделение удалено. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления подразделения. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Subdivision>> GetSubdivisions()
        {
            try
            {
                log.Information($"Получение списка подразделений.");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Subdivisions
                    .Include(a => a.SubdivisionExecutors)
                    .ToListAsync();

                watch.Stop();
                log.Debug($"Список подразделений получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка подразделений. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Subdivision> UpdateSubdivision(Subdivision subdivision)
        {
            try
            {
                log.Information($"Редактирование подразделения: {subdivision.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Subdivisions.SingleOrDefaultAsync(s => s.Id == subdivision.Id);

                if (updated != null)
                {
                    updated.Fullname = subdivision.Fullname;
                    updated.Shortname = subdivision.Shortname;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Подразделение отредактировано. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования подразделения. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
