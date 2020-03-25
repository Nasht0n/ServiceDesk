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
    public class ExecutorGroupRepository : IExecutorGroupRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ExecutorGroupRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<ExecutorGroup> AddExecutorGroup(ExecutorGroup group)
        {
            try
            {
                log.Information($"Добавление группы исполнителей: {group.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.ExecutorGroups.Add(group);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Группа исполнителей добавлена. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления группы исполнителей Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteExecutorGroup(ExecutorGroup group)
        {
            try
            {
                log.Information($"Удаление группы исполнителей: {group.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.ExecutorGroups.SingleOrDefaultAsync(g => g.Id == group.Id);
                context.ExecutorGroups.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Группа исполнителей удалена. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления группы исполнителей. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<ExecutorGroup>> GetExecutorGroups()
        {
            try
            {
                log.Information($"Получение списка групп исполнителей.");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.ExecutorGroups
                    .Include(a => a.Employees)
                    .Include(a => a.Services)                    
                    .ToListAsync();

                watch.Stop();
                log.Debug($"Список групп исполнителей получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка групп исполнителей. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<ExecutorGroup> UpdateExecutorGroup(ExecutorGroup group)
        {
            try
            {
                log.Information($"Редактирование группы исполнителей: {group.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.ExecutorGroups.SingleOrDefaultAsync(g => g.Id == group.Id);

                if (updated != null)
                {
                    updated.Name = group.Name;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Группа исполнителей отредактирована. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования группы исполнителей. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
