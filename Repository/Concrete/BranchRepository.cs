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
    public class BranchRepository : IBranchRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public BranchRepository(ServiceDeskContext context)
        {
            this.context = context;
        }
        public async Task<Branch> AddBranch(Branch branch)
        {
            try
            {
                log.Information($"Добавление отрасли заявки: {branch.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Branches.Add(branch);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Отрасль заявки добавлена. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления отрасли заявки. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteBranch(Branch branch)
        {
            try
            {
                log.Information($"Удаление отрасли заявки: {branch.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Branches.SingleOrDefaultAsync(a => a.Id == branch.Id);
                context.Branches.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Отрасль заявки удалена. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления отрасли заявки. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Branch>> GetBranches()
        {
            try
            {
                log.Information($"Получение списка отраслей заявок");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Branches.ToListAsync();

                watch.Stop();
                log.Debug($"Список отраслей заявок получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка отраслей заявок. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Branch> UpdateBranch(Branch branch)
        {
            try
            {
                log.Information($"Редактирование отрасли заявки: {branch.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Branches.SingleOrDefaultAsync(b => b.Id == branch.Id);

                if (updated != null)
                {
                    updated.Fullname = branch.Fullname;
                    updated.AreaName = branch.AreaName;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Отрасль заявки отредактирована. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования отрасли заявки. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
