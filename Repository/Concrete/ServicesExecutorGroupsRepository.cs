using Domain;
using Domain.Models.ManyToMany;
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
    public class ServicesExecutorGroupsRepository : IServicesExecutorGroupsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ServicesExecutorGroupsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<ServicesExecutorGroup> Add(ServicesExecutorGroup servicesExecutorGroup)
        {
            try
            {
                // log.Information($"Добавление лица, проводящего согласование заявки: {approver.Employee.ToString()} {approver.Service.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.ServicesExecutorGroups.Add(servicesExecutorGroup);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Группа исполнителей заявки добавлена. Затрачено времени: {watch.Elapsed}.");
                return inserted;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления группы исполнителей заявки. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task Delete(ServicesExecutorGroup servicesExecutorGroup)
        {
            try
            {
                // log.Information($"Удаление лица, проводящего согласование заявки: {approver.Employee.ToString()} {approver.Service.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.ServicesExecutorGroups.SingleOrDefaultAsync(sa => sa.ServiceId == servicesExecutorGroup.ServiceId && sa.ExecutorGroupId == servicesExecutorGroup.ExecutorGroupId);
                context.ServicesExecutorGroups.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Группа исполнителей заявки удалена. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления группы исполнителей заявки. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<ServicesExecutorGroup>> GetServicesExecutorGroups()
        {
            try
            {
                log.Information($"Получение списка групп исполнителей заявки.");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.ServicesExecutorGroups
                    .Include(a => a.ExecutorGroup)
                    .Include(a => a.Service)
                    .Include(a=>a.Service.Category)
                    .Include(a=>a.Service.Category.Branch)
                    .ToListAsync();
                watch.Stop();
                log.Debug($"Список групп исполнителей заявки. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка групп исполнителей заявки. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
