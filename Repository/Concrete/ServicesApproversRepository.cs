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
    public class ServicesApproversRepository : IServicesApproversRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ServicesApproversRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<ServicesApprover> AddServicesApprover(ServicesApprover approver)
        {
            try
            {
                log.Information($"Добавление лица, проводящего согласование заявки: {approver.Employee.ToString()} {approver.Service.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.ServicesApprovers.Add(approver);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Лицо, проводящее согласование заявки добавлено. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления лица, проводящего согласование заявки. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteServicesApprover(ServicesApprover approver)
        {
            try
            {
                log.Information($"Удаление лица, проводящего согласование заявки: {approver.Employee.ToString()} {approver.Service.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.ServicesApprovers.SingleOrDefaultAsync(sa => sa.ServiceId == approver.ServiceId && sa.EmployeeId == approver.EmployeeId);
                context.ServicesApprovers.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Лицо, проводящее согласование заявки удалено. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления записи лица, проводящего согласование заявки. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<ServicesApprover>> GetServicesApprovers()
        {
            try
            {
                log.Information($"Получение списка лиц проводящих согласование.");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.ServicesApprovers
                    .Include(a => a.Employee)
                    .Include(a => a.Service)
                    .ToListAsync();
                watch.Stop();
                log.Debug($"Список лиц проводящих согласование получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка лиц проводящих согласование заявки. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
